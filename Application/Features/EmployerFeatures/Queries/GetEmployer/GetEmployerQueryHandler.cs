using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Queries.GetEmployer
{
    internal class GetEmployerQueryHandler : IRequestHandler<GetEmployerQuery, OperationResult<Employer>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetEmployerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Employer>> Handle(GetEmployerQuery request, CancellationToken cancellationToken)
        {

            var employer = await _unitOfWork.ReadEmployerRepository.FirstOrDefaultAsync(x=> x.EmployerId == request.Id);

            if (employer is not null)
                return OperationResult<Employer>.SuccessResult(employer);

            return OperationResult<Employer>.FailureResult("There is no employer !!!");
        }
    }
}
