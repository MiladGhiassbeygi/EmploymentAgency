using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Commands.DeleteEmployer
{
    public record DeleteEmployerCommand(long id) : IRequest<OperationResult<Employer>>;

}
