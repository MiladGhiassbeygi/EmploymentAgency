﻿using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Contract.Queries
{
    internal class GetSuccessedContractsQueryHandler : IRequestHandler<GetSuccessedContractsQuery, OperationResult<List<SuccessedContract>>>
    {

        private readonly IUnitOfWork _unitOfWork;

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
