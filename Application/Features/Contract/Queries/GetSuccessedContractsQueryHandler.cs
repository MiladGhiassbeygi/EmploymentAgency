using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contract.Queries
{
    internal class GetSuccessedContractsQueryHandler : IRequestHandler<GetSuccessedContractsQuery, OperationResult<List<SuccessedContract>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetSuccessedContractsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<SuccessedContract>>> Handle(GetSuccessedContractsQuery request, CancellationToken cancellationToken)
        {

            var successedContract = await _unitOfWork.ReadSuccessedContractRepository.GetAllAsync();

            if (successedContract is not null)
                return OperationResult<List<SuccessedContract>>.SuccessResult(successedContract);

            return OperationResult<List<SuccessedContract>>.FailureResult("There is no Successed Contract !!!");
        }


    }
}
