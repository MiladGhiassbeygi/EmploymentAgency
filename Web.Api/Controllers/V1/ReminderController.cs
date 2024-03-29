﻿using Application.Features.Reminders.Command;
using Application.Features.Reminders.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Dto.Reminder;
using Web.Api.Form.Reminder;
using WebFramework.BaseController;

namespace Web.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Reminder")]
    [ApiController]
    [Authorize]
    public class ReminderController : BaseController
    {
        private readonly ISender _sender;

        public ReminderController(ISender sender)
        {
            _sender = sender;
        }

        [Authorize]
        [HttpPost("CreateReminder")]
        public async Task<IActionResult> CreateReminder(CreateReminderForm model)
        {
            var commandResult = await _sender.Send(new CreateReminderCommand(model.EventDate,model.NoteTitle,model.Note,UserId));
                

            if (commandResult.IsSuccess)
            {
                CreateReminderDto jobSeekerDto = new CreateReminderDto()
                {
                    EventDate = model.EventDate,
                    NoteTitle = model.NoteTitle,
                    Note = model.Note,
                };

                return base.OperationResult(commandResult);
            }
            return base.OperationResult(commandResult);
        }

        [HttpPut("UpdateReminder")]
        public async Task<IActionResult> UpdateReminder(UpdateReminderForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new UpdateReminderCommand(input.ReminderId, input.EventDate, input.NoteTitle, input.Note)));
        }

        [HttpDelete("DeleteReminder")]
        public async Task<IActionResult> DeleteReminder(DeleteReminderForm input, CancellationToken cancellationToken)
        {
            return base.OperationResult(await _sender.Send(new DeleteReminderCommand(input.ReminderId)));
        }

        [Authorize]
        [HttpGet("GetReminder")]
        public async Task<IActionResult> GetReminder()
        {
            return base.OperationResult(await _sender.Send(new GetReminderQuery(UserId)));
        }
    }
}
