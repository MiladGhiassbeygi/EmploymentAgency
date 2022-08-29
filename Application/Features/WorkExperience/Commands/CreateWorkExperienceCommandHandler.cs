using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.CreateWorkExperience
{
    internal class CreateWorkExperienceCommandHandler : IRequestHandler<CreateWorkExperienceCommand, OperationResult<WorkExperience>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<WorkExperienceAdded> _channel;

        public CreateWorkExperienceCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<WorkExperienceAdded> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<WorkExperience>> Handle(CreateWorkExperienceCommand request, CancellationToken cancellationToken)
        {

            var checkAnySkillIds = await _unitOfWork.ReadSkillRepository.AnyListAsync(request.skillIds);
            if(!checkAnySkillIds)
                return OperationResult<WorkExperience>.FailureResult("Some Skill Ids Are Invalid !!!");


            var workExperience = new WorkExperience
            {

                JobTitle = request.jobTitle,
                HoursOfWork = request.hoursOfWork,
                StartDate = request.startDate,
                EndDate = request.endDate,
                SalaryPaid = request.salaryPaid,
                TypeOfCooperation = request.typeOfCooperation,
                HireCompanies = request.hireCompanies,
                JobSeekerId = request.jobSeekerId
            };

            var result = await _unitOfWork.WorkExperienceRepository.CreateWorkExperienceAsync(workExperience);

            await _unitOfWork.CommitAsync();

            foreach(var skillId in request.skillIds)
            {
                await _unitOfWork.WorkExperienceSkillRepository.CreateWorkExperienceSkillAsync(new WorkExperienceSkill { SkillId = skillId, WorkExperienceId = result.Id });
            }

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new WorkExperienceAdded { WorkExperienceId = workExperience.Id }, cancellationToken);

            return OperationResult<WorkExperience>.SuccessResult(workExperience);
        }
    }
}
