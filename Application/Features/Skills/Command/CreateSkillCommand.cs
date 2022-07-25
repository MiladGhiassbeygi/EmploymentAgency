using Application.Models.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skills.Command
{
    public record CreateSkillCommand(string Title,byte Percentage) : IRequest<OperationResult<Skill>>;
}
