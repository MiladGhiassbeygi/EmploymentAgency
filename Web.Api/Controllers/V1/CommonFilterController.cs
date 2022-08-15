using Application.Features.EmployerFeatures.Queries.FilterEmpolyer;
using Application.Features.JobFeatures.Queries.FilterJob;
using Domain.ReadModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{

    public enum FilterType
    {
        Employer = 1,
        Job = 2,
        JobSeeker = 3,
    }

    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/CommonFilter")]
    [ApiController]
    public class CommonFilterController : BaseController
    {
        private readonly ISender _sender;

        public CommonFilterController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> Filter([FromQuery] FilterType type, [FromQuery] string term)
        {
            switch (type)
            {
                case FilterType.Employer:
                    {
                        return base.OperationResult(await _sender.Send(new FilterEmpolyerQuery(term)));
                    }
                case FilterType.Job:
                    {
                        return base.OperationResult(await _sender.Send(new FilterJobQuery(term)));
                    }

            }
            return base.OperationResult(BadRequest("Invalid Input Param's"));
        }
    }
}
