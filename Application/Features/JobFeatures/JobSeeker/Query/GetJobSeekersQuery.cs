﻿using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures
{
    public record GetJobSeekersQuery : IRequest<OperationResult<List<JobSeeker>>>;


}
