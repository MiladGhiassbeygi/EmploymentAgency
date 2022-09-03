using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures.Queries
{
    internal class GetJobQueryHandler : IRequestHandler<GetJobQuery, OperationResult<Job>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetJobQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Job>> Handle(GetJobQuery request, CancellationToken cancellationToken)
        {

            var job = await _unitOfWork.ReadJobRepository.FirstOrDefaultAsync(x=> x.JobId == request.Id);

            if (job is not null)
                return OperationResult<Job>.SuccessResult(job);

            return OperationResult<Job>.FailureResult("There is no job !!!");
        }

       
    }
}