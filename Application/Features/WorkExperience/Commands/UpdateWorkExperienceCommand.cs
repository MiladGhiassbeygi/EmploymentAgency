using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.WorkExperiences.Commands
{
    public record UpdateWorkExperienceCommand(int id, string jobTitle, int hoursOfWork, DateTime startDate, DateTime endDate,decimal salaryPaid, string typeOfCooperation,string hireCompanies) : IRequest<OperationResult<WorkExperience>>;
}
