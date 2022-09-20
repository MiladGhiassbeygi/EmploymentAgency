using Application.Features.Contract.Queries;
using Application.Features.EmployerFeatures.Queries.FilterEmpolyer;
using Application.Features.JobFeatures.Queries.FilterJob;
using Application.Features.JobFeatures.Queries.FilterJobSeeker;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    
    public enum FilterType
    {
        [Display(Name = "Emoloyer")]
        Employer = 1,
        [Display(Name = "Job")]
        Job = 2,
        [Display(Name = "JobSeeker")]
        JobSeeker = 3,
        [Display(Name = "HiredPeople")]
        HiredPeople = 4
    }

    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/CommonFilter")]
    [ApiController]
    [Authorize]
    public class CommonFilterController : BaseController
    {
        private readonly ISender _sender;
        
        public CommonFilterController(ISender sender)
        {
            _sender = sender;
        }
      
        /// <summary>
        ///Employer = 1,
        ///Job = 2,
        ///JobSeeker = 3,
        ///HiredPeople = 4
        /// </summary>
        /// <returns></returns>
        [HttpGet("Filter")]
        public async Task<IActionResult> Filter([FromQuery] FilterType type, [FromQuery] string term)
        {
            
                switch (type)
                {
                    case FilterType.Employer:
                        {
                            return base.OperationResult(await _sender.Send(new FilterEmpolyerQuery(term,UserId)));
                        }
                    case FilterType.Job:
                        {
                            return base.OperationResult(await _sender.Send(new FilterJobQuery(term,UserId)));
                        }
                    case FilterType.JobSeeker:
                        {
                            return base.OperationResult(await _sender.Send(new FilterJobSeekerQuery(term,UserId)));
                        }
                    case FilterType.HiredPeople:
                    {
                        return base.OperationResult(await _sender.Send(new FilterSuccessedContractQuery(term, UserId)));
                    }
            }
                        return base.OperationResult(BadRequest("Invalid Input Param's"));
        }
    }
}
