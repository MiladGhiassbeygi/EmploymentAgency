﻿using Application.Models.Common;
using Domain.Entities;
using MediatR;


namespace Application.Features.Contract.Commands
{
    public record CreateSuccessedContractCommand(long id,long employerId,long jobSeekerId,int employmentAgencyId,bool isAmountFixed,decimal amount) : IRequest<OperationResult<SuccessedContract>>;
}