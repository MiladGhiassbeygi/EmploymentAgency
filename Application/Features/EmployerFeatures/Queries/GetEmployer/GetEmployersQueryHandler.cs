using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Queries.GetEmployer
{
    internal class GetEmployersQueryHandler : IRequestHandler<GetEmployersQuery, OperationResult<List<Employer>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetEmployersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Employer>>> Handle(GetEmployersQuery request, CancellationToken cancellationToken)
        {

            var employer = await _unitOfWork.ReadEmployerRepository.GetWithFilterAsync(x=> x.DefinerId == request.userId);

            if (employer is not null)
                return OperationResult<List<Employer>>.SuccessResult(employer);

            return OperationResult<List<Employer>>.FailureResult("There is no employer !!!");
        }
    }
}
