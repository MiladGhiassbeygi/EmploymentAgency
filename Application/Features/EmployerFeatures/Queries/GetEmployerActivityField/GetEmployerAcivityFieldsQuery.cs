using Application.Models.Common;
using Application.Models.Employer;
using Domain.ReadModel;
using MediatR;


namespace Application.Features.GetEmployerActivityField
{
    public record GetEmployerAcivityFieldsQuery() : IRequest<OperationResult<List<EmployerAcivityField>>>;
}
