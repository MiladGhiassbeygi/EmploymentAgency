using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Reminders.Command
{
    public record UpdateReminderCommand(long id, DateTime eventDate, string noteTitle, string note) : IRequest<OperationResult<ReminderData>>;
}
