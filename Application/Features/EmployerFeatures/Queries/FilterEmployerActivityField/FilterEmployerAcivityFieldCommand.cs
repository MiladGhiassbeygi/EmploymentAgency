using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.EmployerActivityFieldsFeature.Queries.FilterEmployerAcivityField
{
    public record FilterEmployerAcivityFieldCommand(string term) : IRequest<OperationResult<List<EmployerAcivityField>>>;
}
