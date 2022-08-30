using Application.Features.JobFeatures.Command;
using Application.Features.JobFeatures.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Dto.JobUnnecessarySkills;
using Web.Api.Form.JobUnnecessarySkills;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/JobUnnecessarySkills")]
    [ApiController]
    [Authorize]
    public class JobUnnecessarySkillsController : BaseController
    {
        private readonly ISender _sender;
        public JobUnnecessarySkillsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("CreateJobUnnecessarySkills")]
        public async Task<IActionResult> CreateJobEssentialSkills(CreateJobUnnecessarySkillsForm model)
        {
            var commandResult = await _sender.Send(new CreateJobUnnessecarySkillsCommand(model.JobId, model.SkillId
                ));

            if (commandResult.IsSuccess)
            {
                CreateJobUnnecessarySkillsDto jobDto = new CreateJobUnnecessarySkillsDto()
                {
                    JobId = model.JobId,
                    SkillId = model.SkillId,
                };

                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpGet("GetJobUnnecessarySkills")]
        public async Task<IActionResult> GetJobUnnecessarySkills()
        {
            return base.OperationResult(await _sender.Send(new GetJobUnnessecarySkillsQuery()));
        }
    }
}
