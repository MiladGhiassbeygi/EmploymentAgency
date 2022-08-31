using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
namespace Application.Features.EmployerFeatures.Commands
{
    internal class UpdateEmployerActivityFieldCommandHandler : IRequestHandler<UpdateEmployerActivityFieldCommand, OperationResult<EmployerAcivityField>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<EmployerActivityFieldUpdated> _channel;
        public UpdateEmployerActivityFieldCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<EmployerActivityFieldUpdated> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<EmployerAcivityField>> Handle(UpdateEmployerActivityFieldCommand request, CancellationToken cancellationToken)
        {

            var fetchedEmployerActivityField = await _unitOfWork.EmployerAcivityFieldRepository.GetEmployerAcivityFieldByIdAsync(request.id);

            if (fetchedEmployerActivityField is null)
                return OperationResult<EmployerAcivityField>.FailureResult("The Employer Activity Field Is Not Exist");

            fetchedEmployerActivityField.Id= request.id;
            fetchedEmployerActivityField.Title= request.title;

            var result = await _unitOfWork.EmployerAcivityFieldRepository.UpdateEmployerAcivityFieldAsync(fetchedEmployerActivityField);
            try
            {
                await _unitOfWork.CommitAsync();

                await _channel.AddToChannelAsync(new EmployerActivityFieldUpdated { EmployerActivityFieldId = fetchedEmployerActivityField.Id }, cancellationToken);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }

            return OperationResult<EmployerAcivityField>.SuccessResult(fetchedEmployerActivityField);
        }
    }
}
