using Application.Contracts.Persistence;
using Application.Models.Common;
using Application.Models.JobModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.JobFeatures
{
    internal class GetJobSeekerQueryHandler : IRequestHandler<GetJobSeekerQuery, OperationResult<List<GetJobSeekerDto>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetJobSeekerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<GetJobSeekerDto>>> Handle(GetJobSeekerQuery request, CancellationToken cancellationToken)
        {

            var jobSeeker = await _unitOfWork.JobSeekerRepository.GetAll();

            if (jobSeeker is not null)
            {
                var jobSeekerDto = new List<GetJobSeekerDto>();
                jobSeekerDto.AddRange(jobSeekerDto.ConvertAll(x => new GetJobSeekerDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    CountryId = x.CountryId,
                    LinkedinAddress = x.LinkedinAddress,
                    ResumeFilePath = x.ResumeFilePath
                }));

                return OperationResult<List<GetJobSeekerDto>>.SuccessResult(jobSeekerDto);

            }

            return OperationResult<List<GetJobSeekerDto>>.FailureResult("There is no job seeker !!!");
        }
    }
}
    