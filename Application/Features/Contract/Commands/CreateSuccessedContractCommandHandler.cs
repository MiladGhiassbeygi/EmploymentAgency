﻿using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Contract.Commands
{
    internal class CreateSuccessedContractCommandHandler : IRequestHandler<CreateSuccessedContractCommand, OperationResult<SuccessedContract>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<SuccessedContractAdded> _channel;

        public CreateSuccessedContractCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<SuccessedContractAdded> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }

        public async Task<OperationResult<SuccessedContract>> Handle(CreateSuccessedContractCommand request, CancellationToken cancellationToken)
        {

            try
            {
                if (await _unitOfWork.SuccessedContractRepository
                    .FindContractByTermAsync
                    (x=> x.ContractCreatorId == request.contractCreatorId &&
                    x.JobSeekerId == request.jobSeekerId && x.JobId == request.jobId) is not null)
                    return OperationResult<SuccessedContract>.FailureResult("This SuccessedContract Already Exists");

                var SuccessedContract = new SuccessedContract
                {
                    JobId = request.jobId,
                    JobSeekerId = request.jobSeekerId,
                    ContractCreatorId = request.contractCreatorId,
                    IsAmountFixed = request.isAmountFixed,
                    Amount = request.amount
                };

                var result = await _unitOfWork.SuccessedContractRepository.CreateSuccessedContractAsync(SuccessedContract);

                await _unitOfWork.CommitAsync();

                Job job = await _unitOfWork.JobRepository.GetJobAggregateByIdAsync(request.jobId);

                await _channel.AddToChannelAsync(new SuccessedContractAdded { SuccessedContractId = result.Id , EmployerId = job.EmployerId}, cancellationToken);

                return OperationResult<SuccessedContract>.SuccessResult(SuccessedContract);
            }
            catch (Exception ex)
            {
                return OperationResult<SuccessedContract>.FailureResult(ex.Message);
            }
        }
    }
}
