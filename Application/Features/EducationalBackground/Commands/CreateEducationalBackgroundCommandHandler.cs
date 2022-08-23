using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EducationalBackgrounds.Commands
{

    internal class CreateEducationalBackgroundCommandHandler : IRequestHandler<CreateEducationalBackgroundCommand, OperationResult<EducationalBackground>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<EducationalBackgroundAdded> _channel;

        public CreateEducationalBackgroundCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<EducationalBackgroundAdded> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<EducationalBackground>> Handle(CreateEducationalBackgroundCommand request, CancellationToken cancellationToken)
        {
            var educationalbackground = new EducationalBackground
            {
                Degree = request.Degree,
                FieldOfStudy = request.FieldOfStudy,
                JobSeekerId = request.JobSeekerId,
                School = request.School,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            var result = await _unitOfWork.EducationalBackgroundRepository.CreateEducationalBackgroundAsync(educationalbackground);
            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new EducationalBackgroundAdded { EducationalBackgroundId = educationalbackground.Id }, cancellationToken);

            return OperationResult<EducationalBackground>.SuccessResult(educationalbackground);
        }

    }
}