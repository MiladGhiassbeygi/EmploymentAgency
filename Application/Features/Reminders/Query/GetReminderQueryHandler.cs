using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Reminders.Query
{
    internal class GetReminderQueryHandler : IRequestHandler<GetReminderQuery, OperationResult<List<ReminderData>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetReminderQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<ReminderData>>> Handle(GetReminderQuery request, CancellationToken cancellationToken)
        {

            var reminder = await _unitOfWork.ReadReminderRepository.GetWithFilterAsync(x=> x.OwnerId == request.userId);

            if (reminder is not null)
                return OperationResult<List<ReminderData>>.SuccessResult(reminder);

            return OperationResult<List<ReminderData>>.FailureResult("There is no message !!!");
        }
    }
}
