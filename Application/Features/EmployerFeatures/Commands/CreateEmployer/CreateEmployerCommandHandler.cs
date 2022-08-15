using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.Commands.CreateEmployer
{
    internal class CreateEmployerCommandHandler : IRequestHandler<CreateEmployerCommand, OperationResult<Employer>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<EmployerAdded> _channel;
        public CreateEmployerCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<EmployerAdded> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<Employer>> Handle(CreateEmployerCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.EmployerRepository.GetEmployerByNameAsync(request.firstName,request.lastName) is not null)
                return OperationResult<Employer>.FailureResult("This Employer Already Exists");

            var employer = new Employer
            {

                FirstName = request.firstName,
                LastName = request.lastName,
                Address = request.addres,
                PhoneNumber=request.phoneNumber,
                Email=request.email,
                WebsiteLink=request.websiteLink,
                NecessaryExplanation=request.necessaryExplanation,
                IsFixed=request.isFixed,
                ExactAmountRecived=request.exactAmountRecived,
                FieldOfActivityId=request.fieldOfActivityId,
            };

            var result = await _unitOfWork.EmployerRepository.CreateEmployerAsync(employer);
            try
            {
                await _unitOfWork.CommitAsync();

                await _channel.AddToChannelAsync(new EmployerAdded { EmployerId = employer.Id }, cancellationToken);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }
            

            return OperationResult<Employer>.SuccessResult(employer);
        }
    }
}
