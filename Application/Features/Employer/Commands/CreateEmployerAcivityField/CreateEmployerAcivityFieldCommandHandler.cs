using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Employer.Commands.CreateEmployerAcivityField
{
    internal class CreateEmployerAcivityFieldCommandHandler : IRequestHandler<CreateEmployerAcivityFieldCommand, OperationResult<EmployerAcivityField>>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateEmployerAcivityFieldCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<EmployerAcivityField>> Handle(CreateEmployerAcivityFieldCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.EmployerAcivityFieldRepository.GetEmployerAcivityFieldByTitleAsync(request.Title) is not null)
                return OperationResult<EmployerAcivityField>.FailureResult("This EmployerAcivityField Already Exists");

            var employerAcivityField = new EmployerAcivityField { Title = request.Title };

            var result = await _unitOfWork.EmployerAcivityFieldRepository.CreateEmployerAcivityFieldAsync(employerAcivityField);

            await _unitOfWork.CommitAsync();

            return OperationResult<EmployerAcivityField>.SuccessResult(employerAcivityField);
        }
    }
}
