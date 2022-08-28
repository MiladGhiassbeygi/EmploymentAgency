using Application.BackgroundWorker.Common.Events;
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

        public CreateSuccessedContractCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<SuccessedContract>> Handle(CreateSuccessedContractCommand request, CancellationToken cancellationToken)
        {

            try
            {
                if (await _unitOfWork.SuccessedContractRepository.GetSuccessedContractByIdAsync(request.id) is not null)
                    return OperationResult<SuccessedContract>.FailureResult("This SuccessedContract Already Exists");

                var SuccessedContract = new SuccessedContract
                {
                    JobId = request.jobId,
                    JobSeekerId = request.jobSeekerId,
                    Date = request.date,
                    ContractCreatorId = request.contractCreatorId,
                    IsAmountFixed = request.isAmountFixed,
                    Amount = request.amount
                };

                var result = await _unitOfWork.SuccessedContractRepository.CreateSuccessedContractAsync(SuccessedContract);

                await _unitOfWork.CommitAsync();

                return OperationResult<SuccessedContract>.SuccessResult(SuccessedContract);
            }
            catch(Exception ex)
            {
                return OperationResult<SuccessedContract>.FailureResult(ex.Message);
            }
        }
    }
}
