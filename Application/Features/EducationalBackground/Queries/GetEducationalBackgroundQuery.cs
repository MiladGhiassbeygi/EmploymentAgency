using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.EducationalBackgrounds.Queries
{
    public record GetEducationalBackgroundQuery(long Id) : IRequest<OperationResult<EducationalBackground>>;
}
