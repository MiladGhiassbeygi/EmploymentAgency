using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.EmployerCommissionCqrs.Commands
{
    public record CreateEmployerCommissionCommand(bool IsFixed, int Value, long EmployerId) : IRequest<OperationResult<EmployerCommission>>;
}

