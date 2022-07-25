using Application.Command;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skills.Command
{
    internal class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, OperationResult<Skill>>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateSkillCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<Skill>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.SkillRepository.GetSkillByTitleAsync(request.Title) is not null)
                return OperationResult<Skill>.FailureResult("This Skill Already Exists");

            var skill = new Skill { Title = request.Title };

            var result = await _unitOfWork.SkillRepository.CreateSkillAsync(skill);

            await _unitOfWork.CommitAsync();

            return OperationResult<Skill>.SuccessResult(skill);
        }
    }
}
