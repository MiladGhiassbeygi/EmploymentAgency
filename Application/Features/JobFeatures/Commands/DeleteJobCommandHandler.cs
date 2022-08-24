using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.JobFeatures.Commands.DeleteJob
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, OperationResult<Job>>
    {
        private readonly IJobRepository _writeJobRepository;
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<JobDeleted> _channel;
        public DeleteJobCommandHandler(IJobRepository writeJobRepository, IUnitOfWork unitOfWork, ChannelQueue<JobDeleted> channel)
        {
            _writeJobRepository = writeJobRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<Job>> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _writeJobRepository.GetJobByIdAsync(request.id);

            if (job is null)
                return OperationResult<Job>.FailureResult(null);

            await _writeJobRepository.DeleteJobByIdAsync(request.id);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new JobDeleted { JobId = job.Id }, cancellationToken);

            return OperationResult<Job>.SuccessResult(job);
        }
    }
}
