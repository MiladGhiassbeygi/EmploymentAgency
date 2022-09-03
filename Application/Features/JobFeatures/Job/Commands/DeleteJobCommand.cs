using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.JobFeatures.Commands.DeleteJob
{    
        public record DeleteJobCommand(long id) : IRequest<OperationResult<Job>>;
}
