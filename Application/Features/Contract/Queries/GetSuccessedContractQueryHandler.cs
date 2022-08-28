using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Contract.Queries
{
    internal class GetSuccessedContractQueryHandler : IRequestHandler<GetSuccessedContractQuery, OperationResult<SuccessedContract>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetSuccessedContractQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<SuccessedContract>> Handle(GetSuccessedContractQuery request, CancellationToken cancellationToken)
        {

            var successedContract = await _unitOfWork.ReadSuccessedContractRepository.FirstOrDefaultAsync(x => x.SuccessedContractId == request.Id);

            if (successedContract is not null)
                return OperationResult<SuccessedContract>.SuccessResult(successedContract);

            return OperationResult<SuccessedContract>.FailureResult("There is no successed contract !!!");
        }


    }
}
 
    
    