using Application.Contracts.Persistence;
using Application.Models.Common;
using MediatR;
using Domain.ReadModel;

namespace Application.Features.GetEmployerActivityField
{
    internal class GetEmployerAcivityFieldsQueryHandler : IRequestHandler<GetEmployerAcivityFieldsQuery, OperationResult<List<EmployerAcivityField>>>
    {
        readonly IUnitOfWork _unitOfWork;
        public GetEmployerAcivityFieldsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<EmployerAcivityField>>> Handle(GetEmployerAcivityFieldsQuery request, CancellationToken cancellationToken)
        {
            var employerAcivityFields = await _unitOfWork.ReadEmployerActivitiesRepository.GetAllAsync();


            if (employerAcivityFields is not null)
                return OperationResult<List<EmployerAcivityField>>.SuccessResult(employerAcivityFields);

                       return OperationResult<List<EmployerAcivityField>>.FailureResult("There is no Employer Acivity Fields !!");
        }
    }
}
