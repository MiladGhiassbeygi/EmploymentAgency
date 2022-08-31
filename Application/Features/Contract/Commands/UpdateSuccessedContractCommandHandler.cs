using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Contract.Commands
{
    internal class UpdateSuccessedContractCommandHandler : IRequestHandler<UpdateSuccessedContractCommand, OperationResult<SuccessedContract>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<SuccessedContractUpdated> _channel;
        public UpdateSuccessedContractCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<SuccessedContractUpdated> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<SuccessedContract>> Handle(UpdateSuccessedContractCommand request, CancellationToken cancellationToken)
        {

            var fetchedSuccessedContract = await _unitOfWork.SuccessedContractRepository.GetSuccessedContractByIdAsync(request.contractCreatorId);

            if (fetchedSuccessedContract is null)
                return OperationResult<SuccessedContract>.FailureResult("The Successed Contract Is Not Exist");

            fetchedSuccessedContract.Date = request.date;
            fetchedSuccessedContract.IsAmountFixed = request.isAmountFixed;
            fetchedSuccessedContract.Amount = request.amount;
            fetchedSuccessedContract.JobId = request.jobId;
            fetchedSuccessedContract.JobSeekerId = request.jobSeekerId;
            fetchedSuccessedContract.ContractCreatorId = request.contractCreatorId;


            var result = await _unitOfWork.SuccessedContractRepository.UpdateSuccessedContractAsync(fetchedSuccessedContract);
            try
            {
                await _unitOfWork.CommitAsync();

                await _channel.AddToChannelAsync(new SuccessedContractUpdated { SuccessedContractId = fetchedSuccessedContract.Id }, cancellationToken);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }

            fetchedSuccessedContract.ContractCreator = null;
            return OperationResult<SuccessedContract>.SuccessResult(fetchedSuccessedContract);
        }
    }
}
