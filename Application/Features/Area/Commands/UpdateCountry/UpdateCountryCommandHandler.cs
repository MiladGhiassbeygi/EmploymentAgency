using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.Area.Commands
{
    internal class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, OperationResult<Country>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<CountryUpdated> _channel;
        public UpdateCountryCommandHandler(IUnitOfWork unitOfWork, ChannelQueue<CountryUpdated> channel)
        {
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<Country>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {

            var fetchedCountry = await _unitOfWork.CountryRepository.GetCountryByIdAsync(request.id);

            if (fetchedCountry is null)
                return OperationResult<Country>.FailureResult("The Country Is Not Exist");

            fetchedCountry.Id = request.id;
            fetchedCountry.Title = request.title;
            fetchedCountry.AreaCode = request.areaCode;
            fetchedCountry.PostalCode = request.postalCode;


            var result = await _unitOfWork.CountryRepository.UpdateCountryAsync(fetchedCountry);
            try
            {
                await _unitOfWork.CommitAsync();

                await _channel.AddToChannelAsync(new CountryUpdated { CountryId = fetchedCountry.Id }, cancellationToken);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }

            return OperationResult<Country>.SuccessResult(fetchedCountry);
        }
    }
}
