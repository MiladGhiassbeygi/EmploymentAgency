using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.WritePersistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Commands.DeleteEmployer
{
    public class DeleteEmployerCommandHandler : IRequestHandler<DeleteEmployerCommand, OperationResult<Employer>>
    {
        private readonly IEmployerRepository _writeEmployerRepository;
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<EmployerDeleted> _channel;
        public DeleteEmployerCommandHandler(IEmployerRepository writeEmployerRepository, IUnitOfWork unitOfWork, ChannelQueue<EmployerDeleted> channel)
        {
            _writeEmployerRepository = writeEmployerRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<Employer>> Handle(DeleteEmployerCommand request, CancellationToken cancellationToken)
        {
            var employer = await _writeEmployerRepository.GetEmployerByIdAsync(request.id);

            if (employer is null)
                return OperationResult<Employer>.FailureResult(null);

            await _writeEmployerRepository.DeleteEmployerByIdAsync(request.id);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new EmployerDeleted { EmployerId = employer.Id }, cancellationToken);

            return OperationResult<Employer>.SuccessResult(employer);
        }
    }
}
