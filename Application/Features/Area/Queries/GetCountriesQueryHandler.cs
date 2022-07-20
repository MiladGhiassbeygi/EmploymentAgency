using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Area
{
    internal class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery,OperationResult<List<Country>>>
    {
    
        readonly IUnitOfWork _unitOfWork;

        public GetCountriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Country>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {

            var countries = await _unitOfWork.CountryRepository.GetAll();
            if (countries is not null)
                return OperationResult<List<Country>>.SuccessResult(countries);
            return OperationResult<List<Country>>.FailureResult("There is no countries !!!");
        }
    }
}
