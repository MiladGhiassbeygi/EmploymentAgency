using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.WritePersistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.WorkExperiences.Commands
{
    public class DeleteWorkExperienceCommandHandler : IRequestHandler<DeleteWorkExperienceCommand, OperationResult<WorkExperience>>
    {
        private readonly IWorkExperienceRepository _writeWorkExperienceRepository;
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<WorkExperienceDeleted> _channel;
        public DeleteWorkExperienceCommandHandler(IWorkExperienceRepository writeWorkExperienceRepository, IUnitOfWork unitOfWork, ChannelQueue<WorkExperienceDeleted> channel)
        {
            _writeWorkExperienceRepository = writeWorkExperienceRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<WorkExperience>> Handle(DeleteWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            var workExperience = await _writeWorkExperienceRepository.GetWorkExperienceByIdAsync(request.id);

            if (workExperience is null)
                return OperationResult<WorkExperience>.FailureResult(null);


            await _unitOfWork.CommitAsync();

            await _writeWorkExperienceRepository.DeleteWorkExperienceByIdAsync(workExperience.Id);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new WorkExperienceDeleted { WorkExperienceId = workExperience.Id }, cancellationToken);

            return OperationResult<WorkExperience>.SuccessResult(workExperience);
        }
    }
}
