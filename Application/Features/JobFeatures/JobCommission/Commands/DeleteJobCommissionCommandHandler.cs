using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.Persistence.JobContract;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.JobFeatures
{
    public class DeleteJobCommissionCommandHandler : IRequestHandler<DeleteJobCommissionCommand, OperationResult<JobCommission>>
    {
        private readonly IJobCommissionRepository _writeJobCommissionRepository;
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<JobCommissionDeleted> _channel;
        public DeleteJobCommissionCommandHandler(IJobCommissionRepository writeJobCommissionRepository, IUnitOfWork unitOfWork, ChannelQueue<JobCommissionDeleted> channel)
        {
            _writeJobCommissionRepository = writeJobCommissionRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<JobCommission>> Handle(DeleteJobCommissionCommand request, CancellationToken cancellationToken)
        {
            var jobCommission = await _writeJobCommissionRepository.GetJobCommissionByIdAsync(request.id);

            if (jobCommission is null)
                return OperationResult<JobCommission>.FailureResult(null);


            await _unitOfWork.CommitAsync();

            await _writeJobCommissionRepository.DeleteJobCommissionByIdAsync(jobCommission.Id);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new JobCommissionDeleted { JobCommissionId = jobCommission.Id }, cancellationToken);

            return OperationResult<JobCommission>.SuccessResult(jobCommission);
        }
    }
}
