using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.EmployerActivityFieldsFeature.Queries.FilterEmployerAcivityField
{
    internal class FilterEmployerAcivityFieldCommandHandler : IRequestHandler<FilterEmployerAcivityFieldCommand, OperationResult<List<EmployerAcivityField>>>
    {
        readonly IUnitOfWork _unitOfWork;

        public FilterEmployerAcivityFieldCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<EmployerAcivityField>>> Handle(FilterEmployerAcivityFieldCommand request, CancellationToken cancellationToken)
        {
            var activityField = await _unitOfWork.ReadEmployerActivitiesRepository.FilterByTerm(request.term);

            if (activityField is not null)
                return OperationResult<List<EmployerAcivityField>>.SuccessResult(activityField);

            return OperationResult<List<EmployerAcivityField>>.FailureResult("There is no employer !!!");

        }
    }
}
