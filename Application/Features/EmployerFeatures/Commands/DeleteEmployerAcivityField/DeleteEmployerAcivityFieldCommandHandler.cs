using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.WritePersistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Commands
{
    public class DeleteEmployerAcivityFieldCommandHandler : IRequestHandler<DeleteEmployerAcivityFieldCommand, OperationResult<EmployerAcivityField>>
    {
        private readonly IEmployerAcivityFieldRepository _writeEmployerAcivityFieldRepository;
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<EmployerAcivityFieldDeleted> _channel;
        public DeleteEmployerAcivityFieldCommandHandler(IEmployerAcivityFieldRepository writeEmployerAcivityFieldRepository, IUnitOfWork unitOfWork, ChannelQueue<EmployerAcivityFieldDeleted> channel)
        {
            _writeEmployerAcivityFieldRepository = writeEmployerAcivityFieldRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<EmployerAcivityField>> Handle(DeleteEmployerAcivityFieldCommand request, CancellationToken cancellationToken)
        {
            var employerAcivityField = await _writeEmployerAcivityFieldRepository.GetEmployerAcivityFieldByIdAsync(request.id);

            if (employerAcivityField is null)
                return OperationResult<EmployerAcivityField>.FailureResult(null);

            await _writeEmployerAcivityFieldRepository.DeleteEmployerAcivityFieldByIdAsync(request.id);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new EmployerAcivityFieldDeleted { EmployerAcivityFieldId = employerAcivityField.Id }, cancellationToken);

            return OperationResult<EmployerAcivityField>.SuccessResult(employerAcivityField);
        }
    }
}
