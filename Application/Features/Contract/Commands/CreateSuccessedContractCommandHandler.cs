using Application.Contracts.Persistence;
using Application.Features.Area.Commands;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Contract.Commands
{
    internal class CreateSuccessedContractCommandHandler : IRequestHandler<CreateSuccessedContractCommand, OperationResult<SuccessedContract>>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateSuccessedContractCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<SuccessedContract>> Handle(CreateSuccessedContractCommand request, CancellationToken cancellationToken)
        {

            try
            {
                if (await _unitOfWork.SuccessedContractRepository.GetSuccessedContractByIdAsync(request.id) is not null)
                    return OperationResult<SuccessedContract>.FailureResult("This SuccessedContract Already Exists");

                var SuccessedContract = new SuccessedContract
                {
                    EmployerId = request.employerId,
                    JobSeekerId = request.jobSeekerId,
                    EmploymentAgencyId = request.employmentAgencyId,
                    IsAmountFixed = request.isAmountFixed,
                    Amount = request.amount
                };

                var result = await _unitOfWork.SuccessedContractRepository.CreateSuccessedContractAsync(SuccessedContract);

                await _unitOfWork.CommitAsync();

                return OperationResult<SuccessedContract>.SuccessResult(SuccessedContract);
            }
            catch(Exception ex)
            {
                return OperationResult<SuccessedContract>.FailureResult(ex.Message);
            }
        }
    }
}
//long employerId,long jobSeekerId,int employmentAgencyId,bool isAmountFixed,decimal amount