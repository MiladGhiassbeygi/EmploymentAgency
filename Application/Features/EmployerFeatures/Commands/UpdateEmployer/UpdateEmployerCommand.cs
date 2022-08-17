using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Commands.UpdateEmployer
{
    public record UpdateEmployerCommand(
        long id,string firstName, string lastName,
        string addres, string phoneNumber,
        string email, string websiteLink,
        string necessaryExplanation, bool isFixed, decimal exactAmountRecived
        , byte fieldOfActivityId) : IRequest<OperationResult<Employer>>;

}
