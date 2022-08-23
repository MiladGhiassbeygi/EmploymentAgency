using Application.Contracts.Persistence;
using Application.Models.Common;
using Application.Models.Employer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (employerCommissions is not null)
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

            return OperationResult<List<GetEmployerCommissionDto>>.FailureResult("There is no job commission !!!");
        }
    }
}

