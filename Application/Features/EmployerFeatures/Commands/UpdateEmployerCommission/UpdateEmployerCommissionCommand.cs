using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Commands
{
    public record UpdateEmployerCommissionCommand(long employerCommissionId, bool isFixed,int value) : IRequest<OperationResult<EmployerCommission>>;
}
