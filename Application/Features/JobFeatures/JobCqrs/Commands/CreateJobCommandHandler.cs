using Application.Contracts.Persistence;
using Application.Features.Area.Commands;
using Application.Features.JobFeatures.Commands.CreateJob;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.JobFeature.Commands.CreateJob
{
    internal class CreateJobCommandHandler: IRequestHandler<CreateJobCommand, OperationResult<Job>>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateJobCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<Job>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.JobRepository.GetJobByTitleAsync(request.Title) is not null)
                return OperationResult<Job>.FailureResult("This Job Already Exists");

            var job = new Job { Title = request.Title, SalaryMin = request.SalaryMin,SalaryMax  = request.SalaryMax };

            var result = await _unitOfWork.JobRepository.CreateJobAsync(job);

            await _unitOfWork.CommitAsync();

            return OperationResult<Job>.SuccessResult(job);
        }
    }
}
