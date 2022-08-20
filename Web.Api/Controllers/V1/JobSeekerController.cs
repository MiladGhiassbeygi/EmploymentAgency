using Application.Features.JobFeatures;
using Application.Features.JobFeatures.Commands.CreateJobSeeker;
using Application.Features.JobFeatures.UpdateJobSeeker;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Dto.JobSeekerDto;
using Web.Api.Form.JobSeekerForm;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/JobSeeker")]
    [ApiController]
    [Authorize]
    public class JobSeekerController : BaseController
    {
        private readonly ISender _sender;

        public JobSeekerController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost("CreateJobSeeker")]
        public async Task<IActionResult> CreateJobSeeker(CreateJobSeekerForm model)
        {
            var commandResult = await _sender.Send(new CreateJobSeekerCommand(model.FirstName,model.LastName,model.CountryId,model.Email,model.LinkedinAddress,model.ResumeFilePath,UserId
                ));

            if (commandResult.IsSuccess)
            {
                CreateJobSeekerDto jobSeekerDto = new CreateJobSeekerDto()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CountryId = model.CountryId,
                    Email = model.Email,
                    LinkedinAddress = model.LinkedinAddress,
                    ResumeFilePath = model.ResumeFilePath,
                    
                };

                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }


        [HttpPost("UpdateJobSeeker")]
        public async Task<IActionResult> UpdateJobSeeker(UpdateJobSeekerForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new UpdateJobSeekerCommand(input.JobSeekerId,input.FirstName,input.LastName,input.CountryId,input.Email,input.LinkedinAddress,input.ResumeFilePath)));
        }

        [HttpGet("GetJobSeeker")]
        public async Task<IActionResult> GetJobSeeker()
        {
            return base.OperationResult(await _sender.Send(new GetJobSeekerQuery()));
        }
    }
}
