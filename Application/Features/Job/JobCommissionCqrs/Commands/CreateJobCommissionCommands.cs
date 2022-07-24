using Application.Models.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.JobFeatures.JobCommissionCqrs.Commands
{
    public record CreateJobCommissionCommands(bool IsFixed,int Value,long JobId) : IRequest<OperationResult<Domain.Entities.JobCommission>>;
}
