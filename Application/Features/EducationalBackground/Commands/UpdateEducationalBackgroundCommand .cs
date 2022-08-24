using Application.Models.Common;
using Domain.WriteModel;
using MediatR;

namespace Application.Features.EducationalBackgrounds.Commands
{
    public record UpdateEducationalBackgroundCommand(int Id,string School, string Degree, string FieldOfStudy
        , DateTime StartDate, DateTime EndDate, long JobSeekerId) : IRequest<OperationResult<EducationalBackground>>;
}
