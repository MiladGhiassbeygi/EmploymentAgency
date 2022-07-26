using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features
{
      public record CreateJobEssentialSkillsCommand( long JobId, short SkillId) : IRequest<OperationResult<JobEssentialSkills>>;
}
