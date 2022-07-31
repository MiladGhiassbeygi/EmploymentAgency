using Application.Contracts.Persistence;
using Application.Features.JobFeatures.Commands.CreateJob;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.JobFeatures.Commands.CreateJobSeeker
{
    internal class CreateJobSeekerCommandHandler : IRequestHandler<CreateJobSeekerCommand, OperationResult<JobSeeker>>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateJobSeekerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<JobSeeker>> Handle(CreateJobSeekerCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.JobSeekerRepository.GetJobSeekerByIdAsync(request.Id) is not null)
                return OperationResult<JobSeeker>.FailureResult("This Job Seeker Already Exists");

            var jobSeeker = new JobSeeker { Id = request.Id, FirstName = request.FirstName, LastName= request.LastName,CountryId=request.CountryId,LinkedinAddress=request.LinkedinAddress,ResumeFilePath=request.ResumeFilePath};

            var result = await _unitOfWork.JobSeekerRepository.CreateJobSeekerAcync(jobSeeker);

            await _unitOfWork.CommitAsync();

            return OperationResult<JobSeeker>.SuccessResult(jobSeeker);
        }
    }
}
