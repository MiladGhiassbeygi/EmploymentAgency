using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.JobFeatures.Commands.CreateJobSeeker
{
    internal class CreateJobSeekerCommandHandler : IRequestHandler<CreateJobSeekerCommand, OperationResult<JobSeeker>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<JobSeekerAdded> _channel;
        public CreateJobSeekerCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<JobSeekerAdded> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<JobSeeker>> Handle(CreateJobSeekerCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.JobSeekerRepository.IsExist(request.FirstName, request.LastName) is not null)
                return OperationResult<JobSeeker>.FailureResult("This Job Seeker Already Exists");

            var jobSeeker = new JobSeeker
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                CountryId = request.CountryId,
                Email = request.Email,
                LinkedinAddress = request.LinkedinAddress,
                ResumeFilePath = request.ResumeFilePath,
                DefinerId = request.definerId
            };

            var result = await _unitOfWork.JobSeekerRepository.CreateJobSeekerAcync(jobSeeker);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new JobSeekerAdded { JobSeekerId = jobSeeker.Id }, cancellationToken);

            result.Definer = null;
            
            return OperationResult<JobSeeker>.SuccessResult(jobSeeker);
        }
    }
}
