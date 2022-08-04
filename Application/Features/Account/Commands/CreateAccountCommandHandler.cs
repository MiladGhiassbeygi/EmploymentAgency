using Application.Common.BaseChannel;
using Application.Contracts;
using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Models.Common;
using Application.Models.Jwt;
using Domain.WriteModel.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Account.Commands
{
    internal class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, OperationResult<User>>
    {
        private readonly IAppUserManager _userManager;
        private readonly IJwtService _jwtService;
        //private readonly ChannelQueue<CountryAdded> _channel;
        public CreateAccountCommandHandler(IAppUserManager userManager, IJwtService jwtService/*, ChannelQueue<CountryAdded> channel*/)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            //_channel = channel;
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

            if(fechedUser.Succeeded)
                return OperationResult<User>.SuccessResult(user);

            return OperationResult<User>.FailureResult(fechedUser.Errors.FirstOrDefault().Description);
           
            //await _channel.AddToChannelAsync(new CountryAdded { CountryId = country.Id }, cancellationToken);

        }
    }
}
