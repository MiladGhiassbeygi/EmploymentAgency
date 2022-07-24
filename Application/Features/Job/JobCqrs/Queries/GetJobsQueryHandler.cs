using Application.Contracts.Persistence;
using Application.Models.Area;
using Application.Models.Common;
using Application.Models.Job;
using Domain.Entities;
using MediatR;

namespace Application.Features.JobFeatures
{
    internal class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, OperationResult<List<GetJobsDto>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetJobsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<GetJobsDto>>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
        {

            var jobs = await _unitOfWork.JobRepository.GetAll();

            if (jobs is not null)
            {
                var jobsDto = new List<GetJobsDto>();
                jobsDto.AddRange(jobs.ConvertAll(x => new GetJobsDto() {Title = x.Title,SalaryMax=x.SalaryMax,SalaryMin=x.SalaryMin,Description=x.Description,
                HoursOfWork=x.HoursOfWork,EssentialSkills=x.EssentialSkills,AnnualLeave=x.AnnualLeave,ExactAmountRecived=x.ExactAmountRecived,
                    UnnecessarySkills=x.UnnecessarySkills}));

                return OperationResult<List<GetJobsDto>>.SuccessResult(jobsDto);

            }

            return OperationResult<List<GetJobsDto>>.FailureResult("There is no job !!!");
        }
    }
}