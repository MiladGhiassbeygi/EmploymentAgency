using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Reminders.Command
{
    internal class UpdateReminderCommandHandler : IRequestHandler<UpdateReminderCommand, OperationResult<ReminderData>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<ReminderUpdated> _channel;
        public UpdateReminderCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<ReminderUpdated> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<ReminderData>> Handle(UpdateReminderCommand request, CancellationToken cancellationToken)
        {

            var fetchedReminder = await _unitOfWork.ReminderRepository.GetRemindersByIdAsync(request.id);

            if (fetchedReminder is null)
                return OperationResult<ReminderData>.FailureResult("The Reminder Is Not Exist");

            fetchedReminder.Id = request.id;
            fetchedReminder.NoteTitle = request.noteTitle;
            fetchedReminder.EventDate = request.eventDate;
            fetchedReminder.Note = request.note;

            var result = await _unitOfWork.ReminderRepository.UpdateReminderAsync(fetchedReminder);
            try
            {
                await _unitOfWork.CommitAsync();

                await _channel.AddToChannelAsync(new ReminderUpdated { ReminderId = fetchedReminder.Id }, cancellationToken);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }

            return OperationResult<ReminderData>.SuccessResult(fetchedReminder);
        }
    }
}
