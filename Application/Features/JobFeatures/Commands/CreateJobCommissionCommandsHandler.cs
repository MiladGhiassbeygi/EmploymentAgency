﻿using Application.Contracts.Persistence;
using Application.Features.JobFeatures.Commands.CreateJob;
using Application.Models.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.JobFeatures.JobCommissionCqrs.Commands
{
    internal class CreateJobCommissionCommandsHandler : IRequestHandler<CreateJobCommissionCommands, OperationResult<JobCommission>>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateJobCommissionCommandsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<JobCommission>> Handle(CreateJobCommissionCommands request, CancellationToken cancellationToken)
        {
            //if (await _unitOfWork.JobRepository.GetJobCommissionByTitleAsync(request.JobId) is not null)
            //    return OperationResult<JobCommission>.FailureResult("This Job Already Exists");

            var jobCommission = new JobCommission { JobId = request.JobId, IsFixed = request.IsFixed, Value = request.Value };

            var result = await _unitOfWork.JobCommissionRepository.CreateJobCommissionAsync(jobCommission);

            await _unitOfWork.CommitAsync();

            return OperationResult<JobCommission>.SuccessResult(jobCommission);
        }
    }
}