using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Area
{
    internal class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, OperationResult<List<Country>>>
    {

        readonly IUnitOfWork _uow;

        public GetCountriesQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<OperationResult<List<Country>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {

            var countries = await _uow.ReadCountryRepository.GetAllAsync();

            if (countries is not null)
                return OperationResult<List<Country>>.SuccessResult(countries);

            return OperationResult<List<Country>>.FailureResult("There is no countries !!!");
        }
    }
}
