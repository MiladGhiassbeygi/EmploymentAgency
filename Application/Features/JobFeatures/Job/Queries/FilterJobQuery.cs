﻿using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.JobFeatures.Queries.FilterJob
{
    public record FilterJobQuery(string term,long userId) : IRequest<OperationResult<List<Job>>>;

}
