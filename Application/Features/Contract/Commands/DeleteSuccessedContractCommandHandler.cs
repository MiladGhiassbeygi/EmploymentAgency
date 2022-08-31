using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
namespace Application.Features.Contract.Commands
{
    public class DeleteSuccessedContractCommandHandler : IRequestHandler<DeleteSuccessedContractCommand, OperationResult<SuccessedContract>>
    {
        private readonly ISuccessedContractRepository _writeSuccessedContractRepository;
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<SuccessedContractDeleted> _channel;
        public DeleteSuccessedContractCommandHandler(ISuccessedContractRepository writeSuccessedContractRepository, IUnitOfWork unitOfWork, ChannelQueue<SuccessedContractDeleted> channel)
        {
            _writeSuccessedContractRepository = writeSuccessedContractRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<SuccessedContract>> Handle(DeleteSuccessedContractCommand request, CancellationToken cancellationToken)
        {
            var successedContract = await _writeSuccessedContractRepository.GetSuccessedContractByIdAsync(request.id);

            if (successedContract is null)
                return OperationResult<SuccessedContract>.FailureResult(null);

            await _writeSuccessedContractRepository.DeleteSuccessedContractByIdAsync(request.id);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new SuccessedContractDeleted { SuccessedContractId = successedContract.Id }, cancellationToken);

            return OperationResult<SuccessedContract>.SuccessResult(successedContract);
        }
    }
}
