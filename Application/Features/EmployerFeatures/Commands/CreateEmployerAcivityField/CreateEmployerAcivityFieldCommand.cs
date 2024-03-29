﻿using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EmployerActivityFieldsFeature.Commands.CreateEmployerAcivityField
{
    public record CreateEmployerAcivityFieldCommand(string Title,int DefinerId) : IRequest<OperationResult<EmployerAcivityField>>;
}
