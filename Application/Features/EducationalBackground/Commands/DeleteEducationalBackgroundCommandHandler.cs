using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EducationalBackgrounds.Commands
{

    internal class DeleteEducationalBackgroundCommandHandler : IRequestHandler<DeleteEducationalBackgroundCommand, OperationResult<EducationalBackground>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<EducationalBackgroundDeleted> _channel;

        public DeleteEducationalBackgroundCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<EducationalBackgroundDeleted> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<EducationalBackground>> Handle(DeleteEducationalBackgroundCommand request, CancellationToken cancellationToken)
        {
            var fetchedEducationalbackground = await _unitOfWork.EducationalBackgroundRepository.GetEducationalBackgroundByIdAsync(request.Id);

            if (fetchedEducationalbackground is null)
                return OperationResult<EducationalBackground>.FailureResult("The EducationalBackground Is Not Exist");

            var result = await _unitOfWork.EducationalBackgroundRepository.DeleteEducationalBackgroundByIdAsync(request.Id);
            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new EducationalBackgroundDeleted { EducationalBackgroundId = fetchedEducationalbackground.Id }, cancellationToken);

            return OperationResult<EducationalBackground>.SuccessResult(fetchedEducationalbackground);
        }

    }
}