using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EmployerFeatures.Commands.DeleteEmployer
{
    public record DeleteEmployerCommand(long id) : IRequest<OperationResult<Employer>>;


}
