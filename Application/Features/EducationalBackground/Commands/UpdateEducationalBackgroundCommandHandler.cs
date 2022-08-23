using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EducationalBackgrounds.Commands
{

    internal class UpdateEducationalBackgroundCommandHandler : IRequestHandler<UpdateEducationalBackgroundCommand, OperationResult<EducationalBackground>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<EducationalBackgroundUpdated> _channel;

        public UpdateEducationalBackgroundCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<EducationalBackgroundUpdated> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<EducationalBackground>> Handle(UpdateEducationalBackgroundCommand request, CancellationToken cancellationToken)
        {
            var fetchedEducationalbackground = await _unitOfWork.EducationalBackgroundRepository.GetEducationalBackgroundByIdAsync(request.Id);

            if (fetchedEducationalbackground is null)
                return OperationResult<EducationalBackground>.FailureResult("The EducationalBackground Is Not Exist");

            fetchedEducationalbackground.StartDate = request.StartDate;
            fetchedEducationalbackground.EndDate = request.EndDate;
            fetchedEducationalbackground.School = request.School;
            fetchedEducationalbackground.Degree = request.Degree;
            fetchedEducationalbackground.FieldOfStudy = request.FieldOfStudy;
            fetchedEducationalbackground.ModifiedDate = DateTime.Now;


            var result = await _unitOfWork.EducationalBackgroundRepository.UpdateEducationalBackgroundAsync(fetchedEducationalbackground);
            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new EducationalBackgroundUpdated { EducationalBackgroundId = fetchedEducationalbackground.Id }, cancellationToken);

            return OperationResult<EducationalBackground>.SuccessResult(fetchedEducationalbackground);
        }

    }
}