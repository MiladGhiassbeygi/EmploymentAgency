using Application.Models.Common;
using Domain.ReadModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.JobFeatures.Queries.FilterJobSeeker
{
    public record FilterJobSeekerQuery(string term) : IRequest<OperationResult<List<JobSeeker>>>;


}
