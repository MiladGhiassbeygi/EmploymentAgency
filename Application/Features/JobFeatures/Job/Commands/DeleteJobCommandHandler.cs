using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.Persistence.JobContract;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.JobFeatures.Commands.DeleteJob
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, OperationResult<Job>>
    {
        private readonly IJobRepository _writeJobRepository;
        private readonly IJobEssentialSkillsRepository _jobEssentialSkillsRepository;
        private readonly IJobUnnessecarySkillsRepository _jobUnnessecarySkillsRepository;
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<JobDeleted> _channel;
        public DeleteJobCommandHandler(IJobRepository writeJobRepository
            , IJobEssentialSkillsRepository jobEssentialSkillsRepository
            , IJobUnnessecarySkillsRepository jobUnnessecarySkillsRepository
            , IUnitOfWork unitOfWork, ChannelQueue<JobDeleted> channel)
        {
            _writeJobRepository = writeJobRepository;
            _jobEssentialSkillsRepository = jobEssentialSkillsRepository;
            _jobUnnessecarySkillsRepository = jobUnnessecarySkillsRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<Job>> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _writeJobRepository.GetJobAggregateByIdAsync(request.id);

            if (job is null)
                return OperationResult<Job>.FailureResult(null);

            foreach(var item in job.JobEssentialSkills)
            {
                await _jobEssentialSkillsRepository.DeleteJobEssentialSkillsByIdAsync((long)item.JobId,(short)item.SkillId);
            }
            foreach(var item in job.JobUnnecessarySkills)
            {
                await _jobUnnessecarySkillsRepository.DeleteJobUnnessecarySkillsByIdAsync((long)item.JobId, (short)item.SkillId);
            }

            await _unitOfWork.CommitAsync();

            await _writeJobRepository.DeleteJobAsync(job);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new JobDeleted { JobId = job.Id }, cancellationToken);

            return OperationResult<Job>.SuccessResult(job);
        }
    }
}
