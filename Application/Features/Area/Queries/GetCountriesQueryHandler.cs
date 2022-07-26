using Application.Contracts.ReadPersistence.Area;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Area
{
    internal class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, OperationResult<List<Country>>>
    {

        readonly IReadCountryRepository _readCountryRepository;

        public GetCountriesQueryHandler(IReadCountryRepository readCountryRepository)
        {
            _readCountryRepository = readCountryRepository;
        }

        public async Task<OperationResult<List<Country>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {

            var countries = await _readCountryRepository.GetAllAsync();

            if (countries is not null)
                return OperationResult<List<Country>>.SuccessResult(countries);

            return OperationResult<List<Country>>.FailureResult("There is no countries !!!");
        }
    }
}
