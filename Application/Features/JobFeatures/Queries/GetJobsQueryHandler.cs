using Application.Contracts.Persistence;
using Application.Models.Common;
using Application.Models.JobModel;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures.Queries
{
    internal class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, OperationResult<List<Job>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetJobsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Job>>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
        {

            var job = await _unitOfWork.ReadJobRepository.GetAllAsync();

            if (job is not null)
                return OperationResult<List<Job>>.SuccessResult(job);

            return OperationResult<List<Job>>.FailureResult("There is no job !!!");
        }

       
    }
}