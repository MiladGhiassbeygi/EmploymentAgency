using Application.Models.Common;
using MediatR;
using Domain.WriteModel;

namespace Application.Features.JobFeatures.Commands.CreateJobSeeker
{
    public record CreateJobSeekerCommand(string FirstName,string LastName,int CountryId,string Email,string LinkedinAddress,string ResumeFilePath) :IRequest<OperationResult<JobSeeker>>;
}
