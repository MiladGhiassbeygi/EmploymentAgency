using Application.BackgroundWorker.Common.Events;
using Application.Common.BaseChannel;
using Application.Contracts;
using Application.Contracts.Identity;
using Application.Models.Common;
using Domain.WriteModel.User;
using MediatR;

namespace Application.Features.Account.Commands.Register
{
    internal class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, OperationResult<User>>
    {
        private readonly IAppUserManager _userManager;
        private readonly IJwtService _jwtService;
        private readonly ChannelQueue<AccountAdded> _channel;
        public CreateAccountCommandHandler(IAppUserManager userManager, IJwtService jwtService, ChannelQueue<AccountAdded> channel)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _channel = channel;
        }

        public async Task<OperationResult<User>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {

            var user = new User
            {
                Name = request.Name,
                UserName = request.Email,
                NormalizedUserName = request.Email.ToUpper(),
                Email = request.Email,
                EmailConfirmed = true,
                SaltPassword = request.Password,
                PhoneNumber = "09183566483",
                PhoneNumberConfirmed = true,
            };

            var fechedUser = await _userManager.CreateUser(user, request.Password);

            if (fechedUser.Succeeded)
            {
                await _channel.AddToChannelAsync(new AccountAdded { AccountId = user.Id }, cancellationToken);
                return OperationResult<User>.SuccessResult(user);
            }
               
            return OperationResult<User>.FailureResult(fechedUser.Errors.FirstOrDefault().Description);

        }
    }
}
