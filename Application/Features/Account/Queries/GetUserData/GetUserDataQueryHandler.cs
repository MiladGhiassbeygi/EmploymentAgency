using Application.Contracts.ReadPersistence.Account;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Account.Queries.GetUserData
{
    internal class GetUserDataQueryHandler : IRequestHandler<GetUserDataQuery, OperationResult<User>>
    {
        private readonly IReadAccountRepository _readAccountRepository;
        public GetUserDataQueryHandler(IReadAccountRepository readAccountRepository)
        {
            _readAccountRepository = readAccountRepository;
        }
        public async Task<OperationResult<User>> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
        {

            var user = await _readAccountRepository.FirstOrDefaultAsync(x => x.UserId == request.userId);
            if (user == null)
                return OperationResult<User>.FailureResult("Invalid UserId");
            return OperationResult<User>.SuccessResult(user);
        }
    }
}