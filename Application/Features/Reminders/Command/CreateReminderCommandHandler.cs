using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Reminders.Command
{
    internal class CreateReminderCommandHandler : IRequestHandler<CreateReminderCommand, OperationResult<ReminderData>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<ReminderAdded> _channel;
        public CreateReminderCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<ReminderAdded> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<ReminderData>> Handle(CreateReminderCommand request, CancellationToken cancellationToken)
        {
            var reminder = new ReminderData
            {
                EventDate = request.eventDate,
                Note = request.note,
                NoteTitle = request.noteTitle,
                OwnerId = request.ownerId,
            };

            var result = await _unitOfWork.ReminderRepository.CreateReminderAsync(reminder);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new ReminderAdded { ReminderId = reminder.Id }, cancellationToken);

            return OperationResult<ReminderData>.SuccessResult(reminder);
        }
    }
}
