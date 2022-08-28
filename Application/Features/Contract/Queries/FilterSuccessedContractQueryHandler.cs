using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Contract.Queries
{
    internal class FilterSuccessedContractQueryHandler : IRequestHandler<FilterSuccessedContractQuery, OperationResult<List<SuccessedContract>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public FilterSuccessedContractQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<SuccessedContract>>> Handle(FilterSuccessedContractQuery request, CancellationToken cancellationToken)
        {

            var successedContract = await _unitOfWork.ReadSuccessedContractRepository.FilterByTerm(request.term, request.userId, cancellationToken);

            if (successedContract is not null)
                return OperationResult<List<SuccessedContract>>.SuccessResult(successedContract);

            return OperationResult<List<SuccessedContract>>.FailureResult("There is no successed contract !!!");
        }
    }
}
