using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Commands
{
    public class DeleteEmployerCommissionCommandHandler : IRequestHandler<DeleteEmployerCommissionCommand, OperationResult<EmployerCommission>>
    {
        private readonly IEmployerCommissionRepository _writeEmployerCommissionRepository;
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<EmployerCommisionDeleted> _channel;
        public DeleteEmployerCommissionCommandHandler(IEmployerCommissionRepository writeEmployerCommissionRepository, IUnitOfWork unitOfWork, ChannelQueue<EmployerCommisionDeleted> channel)
        {
            _writeEmployerCommissionRepository = writeEmployerCommissionRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<EmployerCommission>> Handle(DeleteEmployerCommissionCommand request, CancellationToken cancellationToken)
        {
            var employerCommission = await _writeEmployerCommissionRepository.GetEmployerCommissionByIdAsync(request.id);

            if (employerCommission is null)
                return OperationResult<EmployerCommission>.FailureResult(null);

            await _writeEmployerCommissionRepository.DeleteEmployerCommissionByIdAsync(request.id);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new EmployerCommisionDeleted { EmployerCommisionId = employerCommission.Id }, cancellationToken);

            return OperationResult<EmployerCommission>.SuccessResult(employerCommission);
        }
    }
}
