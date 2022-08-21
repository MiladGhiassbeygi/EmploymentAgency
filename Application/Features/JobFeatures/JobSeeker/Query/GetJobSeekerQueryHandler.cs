using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures
{
    internal class GetJobSeekerQueryHandler : IRequestHandler<GetJobSeekerQuery, OperationResult<JobSeeker>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetJobSeekerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<JobSeeker>> Handle(GetJobSeekerQuery request, CancellationToken cancellationToken)
        {

            var jobSeeker = await _unitOfWork.ReadJobSeekerRepository.FirstOrDefaultAsync(x=> x.JobSeekerId == request.Id);

            if (jobSeeker is not null)
                return OperationResult<JobSeeker>.SuccessResult(jobSeeker);

            return OperationResult<JobSeeker>.FailureResult("There is no job seeker !!!");
        }
    }
}
    