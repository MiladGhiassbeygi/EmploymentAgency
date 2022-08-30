using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Contract.Queries
{
    internal class GetHiredPeopleSearchContractsQueryHandler : IRequestHandler<GetHiredPeopleSearchContractsQuery, OperationResult<List<SuccessedContract>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHiredPeopleSearchContractsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<SuccessedContract>>> Handle(GetHiredPeopleSearchContractsQuery request, CancellationToken cancellationToken)
        {

            return OperationResult<List<SuccessedContract>>.SuccessResult(await _unitOfWork.ReadSuccessedContractRepository.GetHiredPeopleSearch(request.jobId, request.jobSeekerId, request.employerId, cancellationToken));

        }


    }
}
