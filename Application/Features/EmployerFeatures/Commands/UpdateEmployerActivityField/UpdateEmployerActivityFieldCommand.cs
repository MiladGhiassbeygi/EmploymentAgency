using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
namespace Application.Features.EmployerFeatures.Commands
{
    public record UpdateEmployerActivityFieldCommand(byte id,string title) : IRequest<OperationResult<EmployerAcivityField>>;
}
