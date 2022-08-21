using Application.Models.Common;
using Domain.ReadModel;
using MediatR;


namespace Application.Features.EmployerFeatures.Queries
{
    public record GetEmployerQuery(long Id) : IRequest<OperationResult<Employer>>;
}
