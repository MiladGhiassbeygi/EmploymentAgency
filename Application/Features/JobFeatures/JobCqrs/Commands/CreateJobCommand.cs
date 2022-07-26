using Application.Models.Common;
using Domain.WriteModel;
using MediatR;


namespace Application.Features.JobFeatures.Commands.CreateJob
{
    public record CreateJobCommand(string Title, int HoursOfWork, decimal SalaryMin, decimal SalaryMax
            , byte AnnualLeave, decimal ExactAmountRecived, string Description, string EssentialSkills, string UnnecessarySkills
            , long EmployerId) : IRequest<OperationResult<Job>>;
}
