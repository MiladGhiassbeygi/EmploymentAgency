using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.WorkExperiences.Commands
{
    internal class UpdateWorkExperienceCommandHandler : IRequestHandler<UpdateWorkExperienceCommand, OperationResult<WorkExperience>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<WorkExperienceUpdated> _channel;
        public UpdateWorkExperienceCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<WorkExperienceUpdated> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<WorkExperience>> Handle(UpdateWorkExperienceCommand request, CancellationToken cancellationToken)
        {

            var fetchedWorkExperience = await _unitOfWork.WorkExperienceRepository.GetWorkExperienceByIdAsync(request.id);

            if (fetchedWorkExperience is null)
                return OperationResult<WorkExperience>.FailureResult("The Work Experience Is Not Exist");

            fetchedWorkExperience.Id = request.id;
            fetchedWorkExperience.JobTitle = request.jobTitle;
            fetchedWorkExperience.HoursOfWork = request.hoursOfWork;
            fetchedWorkExperience.StartDate = request.startDate;
            fetchedWorkExperience.EndDate = request.endDate;
            fetchedWorkExperience.SalaryPaid = request.salaryPaid;
            fetchedWorkExperience.TypeOfCooperation = request.typeOfCooperation;
            fetchedWorkExperience.HireCompanies = request.hireCompanies;

            var result = await _unitOfWork.WorkExperienceRepository.UpdateWorkExperienceAsync(fetchedWorkExperience);
            try
            {
                await _unitOfWork.CommitAsync();

                await _channel.AddToChannelAsync(new WorkExperienceUpdated { WorkExperienceId = fetchedWorkExperience.Id }, cancellationToken);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }

            return OperationResult<WorkExperience>.SuccessResult(fetchedWorkExperience);
        }
    }
}
