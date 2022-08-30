using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Skills.Command
{
    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, OperationResult<Skill>>
    {
        private readonly ISkillRepository _writeSkillRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<SkillDeleted> _channel;
        public DeleteSkillCommandHandler(ISkillRepository writeSkillRepository, IUnitOfWork unitOfWork, ChannelQueue<SkillDeleted> channel)
        {
            _writeSkillRepository = writeSkillRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<Skill>> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _writeSkillRepository.GetSkillByIdAsync(request.id);

            if (skill is null)
                return OperationResult<Skill>.FailureResult(null);

            await _writeSkillRepository.DeleteSkillByIdAsync(request.id);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new SkillDeleted { SkillId = skill.Id }, cancellationToken);

            return OperationResult<Skill>.SuccessResult(skill);
        }
    }
}
