using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Area.Commands
{
    public record UpdateCountryCommand (int id,string title,string postalCode,string areaCode) : IRequest<OperationResult<Country>>;
}
