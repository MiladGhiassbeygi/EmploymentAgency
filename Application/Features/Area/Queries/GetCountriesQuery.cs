using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Area
{
    
    public record GetCountriesQuery() : IRequest<OperationResult<List<Country>>>;
}
