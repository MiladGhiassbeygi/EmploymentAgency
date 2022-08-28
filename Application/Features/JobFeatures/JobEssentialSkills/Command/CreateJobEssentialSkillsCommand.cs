using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features
{
      public record CreateJobEssentialSkillsCommand( long JobId, short SkillId) : IRequest<OperationResult<JobEssentialSkills>>;
}
