using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.JobFeatures.Commands.UpdateJob
{
    public record UpdateJobCommand(long id,string title,int hoursOfWork,decimal salaryMin,decimal salaryMax,
        byte annualLeave,decimal exactAmountRecived,string description,string essentialSkills,string unnecessarySkills,string email, string hireCompanies) :IRequest<OperationResult<Job>>;
    
}
