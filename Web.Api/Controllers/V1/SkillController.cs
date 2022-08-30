using Application.Features.Skills.Command;
using Application.Features.Skills.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Form.Skill;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Skill")]
    [ApiController]
    [Authorize]
    public class SkillController : BaseController
    {
        private readonly ISender _sender;

        public SkillController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("CreateSkill")]
        public async Task<IActionResult> CreateSkill(CreateSkillForm model)
        {
            var commandResult = await _sender.Send(new CreateSkillCommand(model.Title,model.Percentage));

            if (commandResult.IsSuccess)
            {
                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpPut("UpdateSkill")]
        public async Task<IActionResult> UpdateCountry(UpdateSkillForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new UpdateSkillCommand(input.SkillId, input.Title, input.Percentage)));
        }

        [HttpGet("GetSkills")]
        public async Task<IActionResult> GetSkills()
        {
            return base.OperationResult(await _sender.Send(new GetSkillQuery()));
        }
    }
}
