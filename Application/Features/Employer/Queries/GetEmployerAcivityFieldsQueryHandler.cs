using Application.Contracts.Persistence;
using Application.Models.Employer;
using Application.Models.Common;
using MediatR;

namespace Application.Features.Employer
{
    internal class GetEmployerAcivityFieldsQueryHandler : IRequestHandler<GetEmployerAcivityFieldsQuery, OperationResult<List<GetEmployerAcivityFieldsDto>>>
    {
        readonly IUnitOfWork _unitOfWork;
        public GetEmployerAcivityFieldsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<GetEmployerAcivityFieldsDto>>> Handle(GetEmployerAcivityFieldsQuery request, CancellationToken cancellationToken)
        {
            var employerAcivityFields = await _unitOfWork.EmployerAcivityFieldRepository.GetAll();

            if(employerAcivityFields is not null)
            {
                var employerAcivityFieldsDto=new List<GetEmployerAcivityFieldsDto>();
                employerAcivityFieldsDto.AddRange(employerAcivityFields.ConvertAll(x => new GetEmployerAcivityFieldsDto() { Id = x.Id, Title = x.Title }));
                return OperationResult<List<GetEmployerAcivityFieldsDto>>.SuccessResult(employerAcivityFieldsDto);
            }

            return OperationResult<List<GetEmployerAcivityFieldsDto>>.FailureResult("There is no Employer Acivity Fields !!");
        }
    }
}
