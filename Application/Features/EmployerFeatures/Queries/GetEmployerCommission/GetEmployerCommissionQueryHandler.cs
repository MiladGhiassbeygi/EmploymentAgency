﻿using Application.Contracts.Persistence;
using Application.Models.Common;
using Application.Models.Employer;
using MediatR;

namespace Application.Features.EmployerFeatures.EmployerCommissionCqrs.Query
{
    internal class GetEmployerCommissionQueryHandler : IRequestHandler<GetEmployerCommissionQuery, OperationResult<List<GetEmployerCommissionDto>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetEmployerCommissionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<GetEmployerCommissionDto>>> Handle(GetEmployerCommissionQuery request, CancellationToken cancellationToken)
        {

            var employerCommissions = await _unitOfWork.EmployerCommissionRepository.GetAll();

            if (employerCommissions.Count() > 0)
            {
                var employerCommissionDto = new List<GetEmployerCommissionDto>();
                employerCommissionDto.AddRange(employerCommissions.ConvertAll(x => new GetEmployerCommissionDto()
                {
                    EmployerId = x.EmployerId,
                    Value = x.Value,
                    IsFixed = x.IsFixed
                }));

                return OperationResult<List<GetEmployerCommissionDto>>.SuccessResult(employerCommissionDto);

            }

            return OperationResult<List<GetEmployerCommissionDto>>.FailureResult("There is no employer commission's !!!");
        }
    }
}

