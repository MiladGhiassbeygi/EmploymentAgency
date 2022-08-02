using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EmployerFeatures.Queries.GetEmployer
{
    internal class GetEmployerQueryHandler : IRequestHandler<GetEmployerQuery, OperationResult<List<Employer>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetEmployerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Employer>>> Handle(GetEmployerQuery request, CancellationToken cancellationToken)
        {

            var employer = await _unitOfWork.ReadEmployerRepository.GetAllAsync();

            if (employer is not null)
                return OperationResult<List<Employer>>.SuccessResult(employer);

            return OperationResult<List<Employer>>.FailureResult("There is no job seeker !!!");
        }
    }
}
