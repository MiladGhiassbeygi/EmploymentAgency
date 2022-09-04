using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Commands
{
    public record DeleteEmployerCommissionCommand(long id) : IRequest<OperationResult<EmployerCommission>>;
}
