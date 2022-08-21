using Application.Models.Common;
using Domain.ReadModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GetWorkExperience
{
    public record GetWorkExperienceQuery() : IRequest<OperationResult<List<WorkExperience>>>;
}
