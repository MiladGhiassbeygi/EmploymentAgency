using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Area.Commands.DeleteCountry
{
    public record DeleteCountryCommand(int id) : IRequest<OperationResult<Country>>;
}
