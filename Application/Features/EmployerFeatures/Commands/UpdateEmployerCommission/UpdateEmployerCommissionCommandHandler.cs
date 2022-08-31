using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Commands
{
    internal class UpdateEmployerCommissionCommandHandler : IRequestHandler<UpdateEmployerCommissionCommand, OperationResult<EmployerCommission>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<EmployerCommisionUpdated> _channel;
        public UpdateEmployerCommissionCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<EmployerCommisionUpdated> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<EmployerCommission>> Handle(UpdateEmployerCommissionCommand request, CancellationToken cancellationToken)
        {

            var fetchedEmployerCommission = await _unitOfWork.EmployerCommissionRepository.GetEmployerCommissionByIdAsync(request.employerCommissionId);

            if (fetchedEmployerCommission is null)
                return OperationResult<EmployerCommission>.FailureResult("The Employer Commission Is Not Exist");

            fetchedEmployerCommission.IsFixed = request.isFixed;
            fetchedEmployerCommission.Value = request.value;

            var result = await _unitOfWork.EmployerCommissionRepository.UpdateEmployerCommissionAsync(fetchedEmployerCommission);
            try
            {
                await _unitOfWork.CommitAsync();

                await _channel.AddToChannelAsync(new EmployerCommisionUpdated { EmployerCommisionId = fetchedEmployerCommission.Id }, cancellationToken);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }

            return OperationResult<EmployerCommission>.SuccessResult(fetchedEmployerCommission);
        }
    }
}
