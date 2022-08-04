using Application.Models.Common;
using MediatR;
using Domain.WriteModel;

namespace Application.Features.EmployerFeatures.Commands.CreateEmployer
{
    public record CreateEmployerCommand(
        string firstName,string lastName,
        string addres,string phoneNumber,
        string email,string websiteLink,
        string necessaryExplanation,byte fieldOfActivityId) 
        : IRequest<OperationResult<Employer>>;
}
