﻿using Application.Models.Common;
using Domain.WriteModel;
using MediatR;


namespace Application.Features.Reminders.Command
{
    public record CreateReminderCommand(DateTime eventDate,string noteTitle,string note,int ownerId) : IRequest<OperationResult<ReminderData>>;
}
