using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures.Queries.FilterJob
{
    internal class FilterJobQueryHandler : IRequestHandler<FilterJobQuery, OperationResult<List<Job>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public FilterJobQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Job>>> Handle(FilterJobQuery request, CancellationToken cancellationToken)
        {

            var job = await _unitOfWork.ReadJobRepository.FilterByTerm(request.term, request.userId,cancellationToken);

            if (job is not null)
                return OperationResult<List<Job>>.SuccessResult(job);

            return OperationResult<List<Job>>.FailureResult("There is no job !!!");
        }
    }
}
