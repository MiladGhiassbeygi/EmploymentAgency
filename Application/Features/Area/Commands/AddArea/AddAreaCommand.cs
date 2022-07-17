using Application.Models.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Area.Commands.AddArea
{
   public record AddAreaCommand(string AreaName,int AreaCode):IRequest<OperationResult<bool>>;
}
