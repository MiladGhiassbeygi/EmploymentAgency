using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Area.Commands.CreateCountry
{
    internal class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, OperationResult<Country>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<CountryAdded> _channel;
        public CreateCountryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Country>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CountryRepository.GetCountryByTitleAsync(request.Title) is not null)
                return OperationResult<Country>.FailureResult("This Country Already Exists");

            var country = new Country { Title = request.Title, PostalCode = request.PostalCode, AreaCode = request.AreaCode };

            var result = await _unitOfWork.CountryRepository.CreateCountryAsync(country);

            await _unitOfWork.CommitAsync();

            return OperationResult<Country>.SuccessResult(country);
        }
    }
}
