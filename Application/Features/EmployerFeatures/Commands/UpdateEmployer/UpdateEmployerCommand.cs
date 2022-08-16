using Application.Models.Common;
using Domain.WriteModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EmployerFeatures.Commands.UpdateEmployer
{
    public record UpdateEmployerCommand(
        long id,string firstName, string lastName,
        string addres, string phoneNumber,
        string email, string websiteLink,
        string necessaryExplanation, bool isFixed, decimal exactAmountRecived
        , byte fieldOfActivityId, int definerId) : IRequest<OperationResult<Employer>>;

}
