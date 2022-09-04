using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Reminders.Command
{
    public record DeleteReminderCommand(long id) : IRequest<OperationResult<ReminderData>>;
}
