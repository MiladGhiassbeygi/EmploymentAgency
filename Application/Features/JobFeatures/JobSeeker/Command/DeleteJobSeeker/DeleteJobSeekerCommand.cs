using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.JobFeatures.DeleteJobSeeker
{
    public record DeleteJobSeekerCommand(long id) : IRequest<OperationResult<JobSeeker>>;
}
