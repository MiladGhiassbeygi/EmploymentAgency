using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.WritePersistence.Reminder;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Reminders.Command
{
    public class DeleteReminderCommandHandler : IRequestHandler<DeleteReminderCommand, OperationResult<ReminderData>>
    {
        private readonly IReminderRepository _writeReminderRepository;
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<ReminderDeleted> _channel;
        public DeleteReminderCommandHandler(IReminderRepository writeReminderRepository, IUnitOfWork unitOfWork, ChannelQueue<ReminderDeleted> channel)
        {
            _writeReminderRepository = writeReminderRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<ReminderData>> Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
        {
            var reminder = await _writeReminderRepository.GetRemindersByIdAsync(request.id);

            if (reminder is null)
                return OperationResult<ReminderData>.FailureResult(null);


            await _unitOfWork.CommitAsync();

            await _writeReminderRepository.DeleteReminderByIdAsync(reminder.Id);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new ReminderDeleted { ReminderId = reminder.Id }, cancellationToken);

            return OperationResult<ReminderData>.SuccessResult(reminder);
        }
    }
}