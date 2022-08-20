using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.JobFeatures.UpdateJobSeeker
{
    internal class UpdateJobSeekerCommandHandler : IRequestHandler<UpdateJobSeekerCommand, OperationResult<JobSeeker>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<JobSeekerUpdated> _channel;
        public UpdateJobSeekerCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<JobSeekerUpdated> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<JobSeeker>> Handle(UpdateJobSeekerCommand request, CancellationToken cancellationToken)
        {

            var fetchedJobSeeker = await _unitOfWork.JobSeekerRepository.GetJobSeekerByIdAsync(request.id);

            if (fetchedJobSeeker is null)
                return OperationResult<JobSeeker>.FailureResult("The Job Seeker Is Not Exist");

            fetchedJobSeeker.FirstName = request.firstName;
            fetchedJobSeeker.LastName = request.lastName;
            fetchedJobSeeker.CountryId = request.countryId;
            fetchedJobSeeker.Email = request.email;
            fetchedJobSeeker.LinkedinAddress = request.linkedinAddress;
            fetchedJobSeeker.ResumeFilePath = request.resumeFilePath;
            

            //fetchedEmployer = _mapper.From(request).Adapt<Employer>();

            var result = await _unitOfWork.JobSeekerRepository.UpdateJobSeekerAsync(fetchedJobSeeker);
            try
            {
                await _unitOfWork.CommitAsync();

                await _channel.AddToChannelAsync(new JobSeekerUpdated { JobSeekerId = fetchedJobSeeker.Id }, cancellationToken);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }

            fetchedJobSeeker.Definer = null;
            return OperationResult<JobSeeker>.SuccessResult(fetchedJobSeeker);
        }
    }
}
