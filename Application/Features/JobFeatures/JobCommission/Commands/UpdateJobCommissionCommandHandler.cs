using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.JobFeatures
{
    internal class UpdateJobCommissionCommandHandler : IRequestHandler<UpdateJobCommissionCommand, OperationResult<JobCommission>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<JobCommissionUpdated> _channel;
        public UpdateJobCommissionCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<JobCommissionUpdated> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<JobCommission>> Handle(UpdateJobCommissionCommand request, CancellationToken cancellationToken)
        {

            var fetchedJobCommission = await _unitOfWork.JobCommissionRepository.GetJobCommissionByIdAsync(request.id);

            if (fetchedJobCommission is null)
                return OperationResult<JobCommission>.FailureResult("The JobCommission Is Not Exist");

            fetchedJobCommission.Id = request.id;

            var result = await _unitOfWork.JobCommissionRepository.UpdateJobCommissionAsync(fetchedJobCommission);
            try
            {
                await _unitOfWork.CommitAsync();

                await _channel.AddToChannelAsync(new JobCommissionUpdated { JobCommissionId = fetchedJobCommission.Id }, cancellationToken);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }

            return OperationResult<JobCommission>.SuccessResult(fetchedJobCommission);
        }
    }
}
