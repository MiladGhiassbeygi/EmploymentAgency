using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.CreateWorkExperience
{
    public record CreateWorkExperienceCommand(string jobTitle,int hoursOfWork,DateTime startDate,DateTime endDate,
        decimal salaryPaid,string typeOfCooperation,string hireCompanies,short [] skillIds, long jobSeekerId) : IRequest<OperationResult<WorkExperience>>;
        
}
