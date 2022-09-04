using Application.Features.CreateWorkExperience;
using Application.Features.GetWorkExperience;
using Application.Features.WorkExperiences.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Dto.WorkExperience;
using Web.Api.Form.WorkExperience;
using Web.Api.Form.WorkExperienceForm;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/WorkExperience")]
    [ApiController]
    [Authorize]
    public class WorkExperienceController : BaseController
    {
        private readonly ISender _sender;

        public WorkExperienceController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("CreateWorkExperience")]
        public async Task<IActionResult> CreateWorkExperience(CreateWorkExperienceForm model)
        {
            var commandResult = await _sender.Send(new CreateWorkExperienceCommand(model.JobTitle, model.HoursOfWork, model.StartDate, model.EndDate
                , model.SalaryPaid, model.TypeOfCooperation, model.HireCompanies, model.SkillIds, model.JobSeekerId
                ));

            if (commandResult.IsSuccess)
            {
                CreateWorkExperienceDto workExperienceDto = new CreateWorkExperienceDto()
                {
                   JobTitle = model.JobTitle,
                   HoursOfWork = model.HoursOfWork,
                   StartDate = model.StartDate,
                   EndDate = model.EndDate,
                   SalaryPaid = model.SalaryPaid,
                   TypeOfCooperation = model.TypeOfCooperation,
                   HireCompanies = model.HireCompanies,
                   SkillIds = model.SkillIds,
                   JobSeekerId = model.JobSeekerId
                };

                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }


        [HttpPut("UpdateWorkExperience")]
        public async Task<IActionResult> UpdateWorkExperience(UpdateWorkExperienceForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new UpdateWorkExperienceCommand(input.WorkExperienceId, input.JobTitle, input.HoursOfWork, input.StartDate, input.EndDate
                ,input.SalaryPaid,input.TypeOfCooperation,input.HireCompanies)));
        }

        [HttpDelete("DeleteWorkExperience")]
        public async Task<IActionResult> DeleteWorkExperience(DeleteWorkExperienceForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new DeleteWorkExperienceCommand(input.WorkExperienceId)));
        }


        [HttpGet("GetWorkExperiences")]
        public async Task<IActionResult> GetWorkExperiences(long jobSeekerId)
        {
            return base.OperationResult(await _sender.Send(new GetWorkExperienceQuery(jobSeekerId)));
        }
    }
}
