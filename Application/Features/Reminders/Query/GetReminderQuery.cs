using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Reminders.Query
{
    public record GetReminderQuery : IRequest<OperationResult<List<ReminderData>>>;
}
