using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Queries.FilterEmpolyer
{
    public record FilterEmpolyerQuery(string term) : IRequest<OperationResult<List<Employer>>>;
}
