using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Employer.Commands.CreateEmployerAcivityField
{
    public record CreateEmployerAcivityFieldCommand(string Title) : IRequest<OperationResult<EmployerAcivityField>>;
}
