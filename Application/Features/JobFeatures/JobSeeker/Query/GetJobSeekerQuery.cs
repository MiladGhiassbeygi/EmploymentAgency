using Application.Models.Common;
using Application.Models.JobModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.JobFeatures
{
    public record GetJobSeekerQuery : IRequest<OperationResult<List<GetJobSeekerDto>>>;


}
