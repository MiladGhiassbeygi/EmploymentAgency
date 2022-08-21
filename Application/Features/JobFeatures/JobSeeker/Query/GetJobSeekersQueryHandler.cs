using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures
{
    internal class GetJobSeekersQueryHandler : IRequestHandler<GetJobSeekersQuery, OperationResult<List<JobSeeker>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetJobSeekersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<JobSeeker>>> Handle(GetJobSeekersQuery request, CancellationToken cancellationToken)
        {

            var jobSeekers = await _unitOfWork.ReadJobSeekerRepository.GetAllAsync();

            if (jobSeekers is not null)
                return OperationResult<List<JobSeeker>>.SuccessResult(jobSeekers);

            return OperationResult<List<JobSeeker>>.FailureResult("There is no job seeker !!!");
        }
    }
}
    