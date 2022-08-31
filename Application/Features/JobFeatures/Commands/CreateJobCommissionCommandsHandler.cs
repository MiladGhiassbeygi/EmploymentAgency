using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.JobFeatures.JobCommissionCqrs.Commands
{
    internal class CreateJobCommissionCommandsHandler : IRequestHandler<CreateJobCommissionCommands, OperationResult<JobCommission>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<JobCommisionAdded> _channel;

        public CreateJobCommissionCommandsHandler(IUnitOfWork unitOfWork, ChannelQueue<JobCommisionAdded> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<JobCommission>> Handle(CreateJobCommissionCommands request, CancellationToken cancellationToken)
        {


            var jobCommission = new JobCommission { JobId = request.JobId, IsFixed = request.IsFixed, Value = request.Value };

            var result = await _unitOfWork.JobCommissionRepository.CreateJobCommissionAsync(jobCommission);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new JobCommisionAdded { JobCommisionId = result.Id, DefinerId = request.DefinerId }, cancellationToken);

            return OperationResult<JobCommission>.SuccessResult(jobCommission);
        }
    }
}
