using Application.Features.Area.Commands.CreateCountry;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Dto.Area;
using WebFramework.BaseController;
using Web.Api.Profile;
using Domain.Entities;
using Application.Features.Area;
using Web.Api.Dto;
using Web.Api.Form;
using Web.Api.Form.Job;
using Application.Features.Job;
using Web.Api.Dto.Jobs;
using Application.Features.Area.Commands.CreateJob;

namespace Web.Api.Controllers.V1
{   [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Job")]
    [ApiController]
    public class JobController : BaseController
    {
        private readonly ISender _sender;

        public JobController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("CreateJob")]
        public async Task<IActionResult> CreateJob(CreateJobForm model)
        {
            var commandResult = await _sender.Send(new CreateJobCommand(model.Title,model.HoursOfWork, model.SalaryMin, model.SalaryMax
                , model.AnnualLeave, model.ExactAmountRecived, model.Description, model.EssentialSkills,model.UnnecessarySkills,model.EmployerId
                ));

            if (commandResult.IsSuccess)
            {
                CreateJobDto jobDto = new CreateJobDto()
                {
                    Title = model.Title,
                    SalaryMax = model.SalaryMax,
                        SalaryMin = model.SalaryMin,
                        UnnecessarySkills = model.UnnecessarySkills,
                        ExactAmountRecived = model.ExactAmountRecived,
                        Description = model.Description


                };
                
                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpGet("GetJobs")]
        public async Task<IActionResult> GetJobs()
        {
            return base.OperationResult(await _sender.Send(new GetJobsQuery()));
        }
    }
}
