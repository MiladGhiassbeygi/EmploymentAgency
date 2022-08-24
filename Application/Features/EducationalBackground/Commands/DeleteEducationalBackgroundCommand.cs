using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EducationalBackgrounds.Commands
{
    public record DeleteEducationalBackgroundCommand(int Id) : IRequest<OperationResult<EducationalBackground>>;
}
