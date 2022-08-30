using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Area;
using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Area.Commands.DeleteCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, OperationResult<Country>>
    {
        private readonly ICountryRepository _writeCountryRepository;
        readonly IUnitOfWork _unitOfWork;
        private readonly ChannelQueue<CountryDeleted> _channel;
        public DeleteCountryCommandHandler(ICountryRepository writeCountryRepository, IUnitOfWork unitOfWork, ChannelQueue<CountryDeleted> channel)
        {
            _writeCountryRepository = writeCountryRepository;
            _unitOfWork = unitOfWork;
            _channel = channel;
        }
        public async Task<OperationResult<Country>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _writeCountryRepository.GetCountryByIdAsync(request.id);

            if (country is null)
                return OperationResult<Country>.FailureResult(null);

            await _writeCountryRepository.DeleteCountryByIdAsync(request.id);

            await _unitOfWork.CommitAsync();

            await _channel.AddToChannelAsync(new CountryDeleted { CountryId = country.Id }, cancellationToken);

            return OperationResult<Country>.SuccessResult(country);
        }
    }
}
