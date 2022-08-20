using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.Persistence.JobContract;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.JobFeatures.DeleteJobSeeker
{
    public class DeleteJobSeekerCommandHandler : IRequestHandler<DeleteJobSeekerCommand, OperationResult<JobSeeker>>
    {
        private readonly IJobSeekerRepository _writeJobSeekerRepository;
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<JobSeekerDeleted> _channel;
        public DeleteJobSeekerCommandHandler(IJobSeekerRepository writeJobSeekerRepository, IUnitOfWork unitOfWork, ChannelQueue<JobSeekerDeleted> channel)
        {
            _writeJobSeekerRepository = writeJobSeekerRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<JobSeeker>> Handle(DeleteJobSeekerCommand request, CancellationToken cancellationToken)
        {
            var jobSeeker = await _writeJobSeekerRepository.GetJobSeekerByIdAsync(request.id);

            if (jobSeeker is null)
                return OperationResult<JobSeeker>.FailureResult(null);

            await _writeJobSeekerRepository.DeleteJobSeekerByIdAsync(request.id);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new JobSeekerDeleted { JobSeekerId = jobSeeker.Id }, cancellationToken);

            return OperationResult<JobSeeker>.SuccessResult(jobSeeker);
        }
    }
}
