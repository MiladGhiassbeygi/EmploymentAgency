using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.JobFeatures.UpdateJobSeeker
{
    public record UpdateJobSeekerCommand(
        long id,string firstName,string lastName,
        int countryId ,string email, 
        string linkedinAddress, string resumeFilePath) : IRequest<OperationResult<JobSeeker>>;


}
