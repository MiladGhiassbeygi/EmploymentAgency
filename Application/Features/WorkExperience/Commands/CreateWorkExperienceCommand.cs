using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CreateWorkExperience
{
    public record CreateWorkExperienceCommand(string jobTitle,int hoursOfWork,DateTime startDate,DateTime endDate,
        decimal salaryPaid,string typeOfCooperation,string hireCompanies,string skills, long jobSeekerId) : IRequest<OperationResult<WorkExperience>>;
        
}
