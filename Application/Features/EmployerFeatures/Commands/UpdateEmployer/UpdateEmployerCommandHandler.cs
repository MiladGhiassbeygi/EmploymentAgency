using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Commands.UpdateEmployer
{
    internal class UpdateEmployerCommandHandler : IRequestHandler<UpdateEmployerCommand, OperationResult<Employer>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<EmployerUpdated> _channel;
        public UpdateEmployerCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<EmployerUpdated> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<Employer>> Handle(UpdateEmployerCommand request, CancellationToken cancellationToken)
        {

            var fetchedEmployer = await _unitOfWork.EmployerRepository.GetEmployerByIdAsync(request.id);

            if (fetchedEmployer is null)
                return OperationResult<Employer>.FailureResult("The Employer Is Not Exist");
         
            fetchedEmployer.FirstName = request.firstName;
            fetchedEmployer.LastName = request.lastName;
            fetchedEmployer.PhoneNumber = request.phoneNumber;
            fetchedEmployer.Address = request.addres;
            fetchedEmployer.WebsiteLink = request.websiteLink;
            fetchedEmployer.NecessaryExplanation = request.necessaryExplanation;
            fetchedEmployer.IsFixed = request.isFixed;
            fetchedEmployer.ExactAmountRecived = request.exactAmountRecived;
            fetchedEmployer.FieldOfActivityId = request.fieldOfActivityId;

            //fetchedEmployer = _mapper.From(request).Adapt<Employer>();

            var result = await _unitOfWork.EmployerRepository.UpdateEmployerAsync(fetchedEmployer);
            try
            {
                await _unitOfWork.CommitAsync();

                await _channel.AddToChannelAsync(new EmployerUpdated { EmployerId = fetchedEmployer.Id }, cancellationToken);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }


            return OperationResult<Employer>.SuccessResult(fetchedEmployer);
        }
    }
}
