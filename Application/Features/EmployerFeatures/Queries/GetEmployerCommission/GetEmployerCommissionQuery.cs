using Application.Models.Common;
using Application.Models.Employer;
using MediatR;

namespace Application.Features.EmployerFeatures.EmployerCommissionCqrs.Query
{
    public record GetEmployerCommissionQuery() : IRequest<OperationResult<List<GetEmployerCommissionDto>>>;
}
