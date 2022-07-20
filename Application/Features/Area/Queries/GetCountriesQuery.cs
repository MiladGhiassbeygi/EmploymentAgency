using Application.Models.Area;
using Application.Models.Common;
using MediatR;

namespace Application.Features.Area
{
    
    public record GetCountriesQuery() : IRequest<OperationResult<List<GetCountriesDto>>>;
}
