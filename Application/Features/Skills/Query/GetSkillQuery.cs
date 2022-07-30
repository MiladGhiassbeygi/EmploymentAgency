using Application.Models.Common;
using Application.Models.Skill;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skills.Query
{
    public record GetSkillQuery() : IRequest<OperationResult<List<GetSkillDto>>>;
}
