﻿using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures
{
    public record GetJobSeekerQuery(long Id) : IRequest<OperationResult<JobSeeker>>;


}
