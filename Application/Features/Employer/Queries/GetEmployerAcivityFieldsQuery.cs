using Application.Models.Common;
using Application.Models.Employer;
using MediatR;


namespace Application.Features.Employer
{
    public record GetEmployerAcivityFieldsQuery() : IRequest<OperationResult<List<GetEmployerAcivityFieldsDto>>>;
}
