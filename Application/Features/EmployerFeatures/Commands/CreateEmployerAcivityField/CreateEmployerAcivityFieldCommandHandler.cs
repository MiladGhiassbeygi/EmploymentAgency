using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerActivityFieldsFeature.Commands.CreateEmployerAcivityField
{
    internal class CreateEmployerAcivityFieldCommandHandler : IRequestHandler<CreateEmployerAcivityFieldCommand, OperationResult<EmployerAcivityField>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<EmployerActivityFieldAdded> _channel;

        public CreateEmployerAcivityFieldCommandHandler(IUnitOfWork unitOfWork,ChannelQueue<EmployerActivityFieldAdded> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }

        public async Task<OperationResult<EmployerAcivityField>> Handle(CreateEmployerAcivityFieldCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.EmployerAcivityFieldRepository.GetEmployerAcivityFieldByTitleAsync(request.Title) is not null)
                return OperationResult<EmployerAcivityField>.FailureResult("This EmployerAcivityField Already Exists");

            var employerAcivityField = new EmployerAcivityField { Title = request.Title };

            var result = await _unitOfWork.EmployerAcivityFieldRepository.CreateEmployerAcivityFieldAsync(employerAcivityField);

            await _unitOfWork.CommitAsync();
            await _channel.AddToChannelAsync(new EmployerActivityFieldAdded { EmployerActivityFieldId = employerAcivityField.Id }, cancellationToken);
            return OperationResult<EmployerAcivityField>.SuccessResult(employerAcivityField);
        }
    }
}
