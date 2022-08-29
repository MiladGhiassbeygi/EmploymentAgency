using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.GetWorkExperience
{
    internal class GetWorkExperienceQueryHandler : IRequestHandler<GetWorkExperienceQuery, OperationResult<List<WorkExperience>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetWorkExperienceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<WorkExperience>>> Handle(GetWorkExperienceQuery request, CancellationToken cancellationToken)
        {

            var workExperience = await _unitOfWork.ReadWorkExperienceRepository.GetAllAsync();

            if (workExperience is not null)
                return OperationResult<List<WorkExperience>>.SuccessResult(workExperience);

            return OperationResult<List<WorkExperience>>.FailureResult("There is no work experience !!!");
        }


    }
}
