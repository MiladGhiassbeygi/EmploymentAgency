﻿using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.JobFeatures.Commands.UpdateJob
{
    internal class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, OperationResult<Job>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<JobUpdated> _channel;
        public UpdateJobCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<JobUpdated> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<Job>> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {

            var fetchedJob = await _unitOfWork.JobRepository.GetJobByIdAsync(request.id);

            if (fetchedJob is null)
                return OperationResult<Job>.FailureResult("The Job Is Not Exist");

            fetchedJob.Id = request.id;
            fetchedJob.Title = request.title;
            fetchedJob.HoursOfWork = request.hoursOfWork;
            fetchedJob.SalaryMin = request.salaryMin;
            fetchedJob.SalaryMax = request.salaryMax;
            fetchedJob.AnnualLeave = request.annualLeave;
            fetchedJob.ExactAmountRecived = request.exactAmountRecived;
            fetchedJob.Description = request.description;
            fetchedJob.Email = request.email;
            fetchedJob.HireCompanies = request.hireCompanies;

            var result = await _unitOfWork.JobRepository.UpdateJobAsync(fetchedJob);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new JobUpdated { JobId = fetchedJob.Id }, cancellationToken);

            fetchedJob.Employer = null;
            return OperationResult<Job>.SuccessResult(fetchedJob);
        }
    }
}
