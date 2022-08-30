using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Skills.Command
{
    internal class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, OperationResult<Skill>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<SkillUpdated> _channel;
        public UpdateSkillCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<SkillUpdated> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<Skill>> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {

            var fetchedSkill = await _unitOfWork.SkillRepository.GetSkillByIdAsync(request.id);

            if (fetchedSkill is null)
                return OperationResult<Skill>.FailureResult("The Skill Is Not Exist");

            fetchedSkill.Id = request.id;
            fetchedSkill.Title = request.title;
            fetchedSkill.Percentage = request.percentage;

            var result = await _unitOfWork.SkillRepository.UpdateSkillAsync(fetchedSkill);
            try
            {
                await _unitOfWork.CommitAsync();

                await _channel.AddToChannelAsync(new SkillUpdated { SkillId = fetchedSkill.Id }, cancellationToken);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }

            return OperationResult<Skill>.SuccessResult(fetchedSkill);
        }
    }
}
