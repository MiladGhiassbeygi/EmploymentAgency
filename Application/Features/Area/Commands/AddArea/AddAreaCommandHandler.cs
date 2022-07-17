using Application.Contracts.Persistence;
using Application.Models.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Area.Commands.AddArea
{
    internal class AddAreaCommandHandler : IRequestHandler<AddAreaCommand, OperationResult<bool>>
    {
        readonly IUnitOfWork _unitOfWork;

        public AddAreaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<bool>> Handle(AddAreaCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CountryRepository.GetCountryByTitleAsync(request.AreaName) is not null)
                return OperationResult<bool>.FailureResult("This Area Already Exists");


            await _unitOfWork.CommitAsync();

            return OperationResult<bool>.SuccessResult(true);
        }
    }
}
