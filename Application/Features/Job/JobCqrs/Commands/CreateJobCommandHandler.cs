using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.JobFeatures.Commands.CreateJob
{
    internal class CreateJobCommandHandler: IRequestHandler<CreateJobCommand, OperationResult<Domain.Entities.Job>>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateJobCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<Domain.Entities.Job>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.JobRepository.GetJobByTitleAsync(request.Title) is not null)
                return OperationResult<Domain.Entities.Job>.FailureResult("This Job Already Exists");

            var job = new Job { Title = request.Title, SalaryMin = request.SalaryMin,SalaryMax  = request.SalaryMax };

            var result = await _unitOfWork.JobRepository.CreateJobAsync(job);

            await _unitOfWork.CommitAsync();

            return OperationResult<Domain.Entities.Job>.SuccessResult(job);
        }
    }
}
