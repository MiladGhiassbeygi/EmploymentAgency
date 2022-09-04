using Application.Contracts.Persistence;
using Application.Models.Common;
using Application.Models.JobModel;
using MediatR;

namespace Application.Features.JobFeatures.JobCommissionCqrs.Queries
{
    internal class GetJobCommissionQueriesHandler : IRequestHandler<GetJobCommissionQueries, OperationResult<List<GetJobCommissionsDto>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetJobCommissionQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<GetJobCommissionsDto>>> Handle(GetJobCommissionQueries request, CancellationToken cancellationToken)
        {

            var jobCommissions = await _unitOfWork.ReadJobCommissionRepository.GetWithFilterAsync(x=> x.JobCommissionId == request.jobCommissionId);

            if (jobCommissions is not null)
            {
                var jobCommissionsDto = new List<GetJobCommissionsDto>();
                jobCommissionsDto.AddRange(jobCommissions.ConvertAll(x => new GetJobCommissionsDto()
                {
                    Value = x.Value,
                    IsFixed= x.IsFixed
                }));

                return OperationResult<List<GetJobCommissionsDto>>.SuccessResult(jobCommissionsDto);

            }

            return OperationResult<List<GetJobCommissionsDto>>.FailureResult("There is no job commission !!!");
        }
    }
}
