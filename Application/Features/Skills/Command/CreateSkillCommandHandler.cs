using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using MongoDB.Driver.Core.Bindings;

namespace Application.Features.Skills.Command
{
    internal class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, OperationResult<Skill>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<SkillAdded> _channel;

        public CreateSkillCommandHandler(IUnitOfWork unitOfWork,ChannelQueue<SkillAdded> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<Skill>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.SkillRepository.GetSkillByTitleAsync(request.Title) is not null)
                return OperationResult<Skill>.FailureResult("This Skill Already Exists");

            var skill = new Skill { Title = request.Title };

            var result = await _unitOfWork.SkillRepository.CreateSkillAsync(skill);

            
            await _unitOfWork.CommitAsync();
            await _channel.AddToChannelAsync(new SkillAdded { SkillId = skill.Id }, cancellationToken);

            return OperationResult<Skill>.SuccessResult(skill);
        }
    }
}
