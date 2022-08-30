using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.JobFeatures.Command
{
    public record CreateJobUnnessecarySkillsCommand(long jobId ,short skillId) : IRequest<OperationResult<JobUnnessecarySkills>>;
    
    
}
