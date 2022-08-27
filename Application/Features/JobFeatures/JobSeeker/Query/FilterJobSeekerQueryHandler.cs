using Application.Contracts.Persistence;
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
    internal class FilterJobSeekerQueryHandler : IRequestHandler<FilterJobSeekerQuery, OperationResult<List<JobSeeker>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public FilterJobSeekerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<JobSeeker>>> Handle(FilterJobSeekerQuery request, CancellationToken cancellationToken)
        {

            var jobSeeker = await _unitOfWork.ReadJobSeekerRepository.FilterByTerm(request.term,request.userId,cancellationToken);

            if (jobSeeker is not null)
                return OperationResult<List<JobSeeker>>.SuccessResult(jobSeeker);

            return OperationResult<List<JobSeeker>>.FailureResult("There is no job !!!");
        }
    }
}
