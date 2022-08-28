using Application.Contracts.Persistence;
using Application.Features.JobFeatures.Commands;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

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
