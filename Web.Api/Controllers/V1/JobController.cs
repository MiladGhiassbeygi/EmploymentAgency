using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebFramework.BaseController;
using Web.Api.Form.Job;
using Web.Api.Dto.Jobs;
using Application.Features.JobFeatures.Queries;
using Application.Features.JobFeatures.Commands.CreateJob;
using Application.Features.JobFeatures.Queries.FilterJob;
using Application.Features.JobFeatures.Commands.UpdateJob;
using Web.Api.Form.JobForm;
using Application.Features.JobFeatures.Commands.DeleteJob;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
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
            var commandResult = await _sender.Send(new CreateJobCommand(model.Title, model.HoursOfWork, model.SalaryMin, model.SalaryMax
                , model.AnnualLeave, model.ExactAmountRecived, model.Description, model.EssentialSkills, model.UnnecessarySkills,model.Email,model.HireCompanies, model.EmployerId
                ));
           

            if (commandResult.IsSuccess)
            {
                CreateJobDto jobDto = new CreateJobDto()
                {
                    Title = model.Title,
                    HoursOfWork = model.HoursOfWork,
                    SalaryMax = model.SalaryMax,
                    SalaryMin = model.SalaryMin,
                    AnnualLeave = model.AnnualLeave,
                    ExactAmountRecived = model.ExactAmountRecived,
                    Description = model.Description,
                    EssentialSkills = model.EssentialSkills,
                    UnnecessarySkills = model.UnnecessarySkills,
                    Email = model.Email,
                    HireCompanies = model.HireCompanies,
                    EmployerId = model.EmployerId
                };

                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpPut("UpdateJob")]
        public async Task<IActionResult> UpdateJob(UpdateJobForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new UpdateJobCommand(input.Id, input.Title, input.HoursOfWork, input.SalaryMin, input.SalaryMax, input.AnnualLeave, input.ExactAmountRecived,
                input.Description, input.EssentialSkills,input.UnnecessarySkills,input.Email,input.HireCompanies)));
        }

        [HttpDelete("DeleteJob")]
        public async Task<IActionResult> DeleteEmployer(DeleteJobForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new DeleteJobCommand(input.Id)));
        }

        [HttpGet("GetJobs")]
        public async Task<IActionResult> GetJobs()
        {
            return base.OperationResult(await _sender.Send(new GetJobsQuery()));
        }

        [HttpGet("GetJobById")]
        public async Task<IActionResult> GetJobById(long Id)
        {
            return base.OperationResult(await _sender.Send(new GetJobQuery(Id)));
        }

        [HttpGet("Filter")]
        public async Task <IActionResult> Filter([FromQuery]string term)
        {
            return base.OperationResult(await _sender.Send(new FilterJobQuery(term)));
        }

    }
}
