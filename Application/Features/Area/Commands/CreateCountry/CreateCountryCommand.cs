using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Area.Commands.CreateCountry
{
   public record CreateCountryCommand(string Title,string PostalCode, string AreaCode):IRequest<OperationResult<Country>>;
}
