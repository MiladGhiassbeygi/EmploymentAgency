using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Commands
{
    public record DeleteEmployerAcivityFieldCommand(byte id) : IRequest<OperationResult<EmployerAcivityField>>;
}
