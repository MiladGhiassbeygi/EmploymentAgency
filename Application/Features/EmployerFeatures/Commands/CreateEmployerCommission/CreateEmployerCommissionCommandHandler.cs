using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerFeatures.EmployerCommissionCqrs.Commands
{
    internal class CreateEmployerCommissionCommandHandler : IRequestHandler<CreateEmployerCommissionCommand, OperationResult<EmployerCommission>>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateEmployerCommissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<EmployerCommission>> Handle(CreateEmployerCommissionCommand request, CancellationToken cancellationToken)
        {
            var employerCommission = new EmployerCommission { EmployerId = request.EmployerId, IsFixed = request.IsFixed, Value = request.Value };

            var result = await _unitOfWork.EmployerCommissionRepository.CreateEmployerCommissionAsync(employerCommission);

            await _unitOfWork.CommitAsync();

            return OperationResult<EmployerCommission>.SuccessResult(employerCommission);
        }
    }
}
