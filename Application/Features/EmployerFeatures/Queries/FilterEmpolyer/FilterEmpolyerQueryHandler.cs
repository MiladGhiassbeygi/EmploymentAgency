using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Queries.FilterEmpolyer
{


    internal class FilterEmpolyerQueryHandler : IRequestHandler<FilterEmpolyerQuery, OperationResult<List<Employer>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public FilterEmpolyerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Employer>>> Handle(FilterEmpolyerQuery request, CancellationToken cancellationToken)
        {

            var employer = await _unitOfWork.ReadEmployerRepository.FilterByTerm(request.term);

            if (employer is not null)
                return OperationResult<List<Employer>>.SuccessResult(employer);

            return OperationResult<List<Employer>>.FailureResult("There is no employer !!!");
        }
    }
}
//(x => x.FirstName.Contains(request.term)).