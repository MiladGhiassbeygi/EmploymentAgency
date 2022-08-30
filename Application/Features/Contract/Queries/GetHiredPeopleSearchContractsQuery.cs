using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.Contract.Queries
{
    public record GetHiredPeopleSearchContractsQuery(long jobId,long jobSeekerId,long employerId) : IRequest<OperationResult<List<SuccessedContract>>>;
}
