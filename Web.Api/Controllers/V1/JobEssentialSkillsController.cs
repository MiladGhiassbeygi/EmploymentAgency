using Application.Features;
using Application.Features.JobFeatures.JobEssentialSkills.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Dto.JobEssentialSkillsDto;
using Web.Api.Form.JobEssentialSkillsForm;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/JobEssentialSkills")]
    [ApiController]
    [Authorize]
    public class JobEssentialSkillsController : BaseController
    {
        private readonly ISender _sender;
        public JobEssentialSkillsController(ISender sender) 
        {
            _sender = sender;
        }

        [HttpPost("CreateJobEssentialSkills")]
        public async Task<IActionResult> CreateJobEssentialSkills(CreateJobEssentialSkillsForm model)
        {
            var commandResult = await _sender.Send(new CreateJobEssentialSkillsCommand(model.JobId,model.SkillId
                ));

            if (commandResult.IsSuccess)
            {
                CreateJobEssentialSkillsDto jobDto = new CreateJobEssentialSkillsDto()
                {
                     JobId = model.JobId,
                     SkillId = model.SkillId,
                };

                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpGet("GetJobEssentialSkills")]
        public async Task<IActionResult> GetJobEssentialSkills()
        {
            return base.OperationResult(await _sender.Send(new GetJobEssentialSkillsQuery()));
        }
    }
}
