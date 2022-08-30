using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures
{
    internal class GetAvailableJobsForJobSeekerQueryHandler : IRequestHandler<GetAvailableJobsForJobSeekerQuery, OperationResult<List<Job>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetAvailableJobsForJobSeekerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Job>>> Handle(GetAvailableJobsForJobSeekerQuery request, CancellationToken cancellationToken)
        {
            var jobSeekerSkills = await _unitOfWork.ReadJobSeekerSkillsRepository.GetWithFilterAsync(x => x.JobSeekerId == request.jobSeekerId);
            List<short> skillIds = jobSeekerSkills.Select(x=> x.SkillId).ToList();

            var jobSkills = await _unitOfWork.ReadJobEssentialRepository.GetWithFilterAsync(x=> skillIds.Contains(x.SkillId));
            List<long> jobIds = jobSkills.Select(x => x.JobId).ToList();

            var availableJobs = await _unitOfWork.ReadJobRepository.GetWithFilterAsync(x => jobIds.Contains(x.JobId) && x.DefinerId == request.definerId);

            return OperationResult<List<Job>>.SuccessResult(availableJobs);

        }

       
    }
}