using Application.Models.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Area
{
    
    public record GetCountriesQuery() : IRequest<OperationResult<List<Country>>>;
}
