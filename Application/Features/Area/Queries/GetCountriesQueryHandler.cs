using Application.Contracts.Persistence;
using Application.Models.Area;
using Application.Models.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Area
{
    internal class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, OperationResult<List<GetCountriesDto>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetCountriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<GetCountriesDto>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {

            var countries = await _unitOfWork.CountryRepository.GetAll();

            if (countries is not null)
            {
                var countriesDto = new List<GetCountriesDto>();
                countriesDto.AddRange(countries.ConvertAll(x => new GetCountriesDto() { Id = x.Id, Title = x.Title, PostalCode = x.PostalCode, AreaCode = x.AreaCode }));
                return OperationResult<List<GetCountriesDto>>.SuccessResult(countriesDto);

            }

            return OperationResult<List<GetCountriesDto>>.FailureResult("There is no countries !!!");
        }
    }
}
