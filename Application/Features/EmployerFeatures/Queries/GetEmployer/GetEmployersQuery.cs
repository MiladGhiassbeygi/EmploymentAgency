using Application.Models.Common;
using Domain.ReadModel;
using MediatR;


namespace Application.Features.EmployerFeatures.Queries.GetEmployer
{
    public record GetEmployersQuery(long userId) : IRequest<OperationResult<List<Employer>>>;
}
