using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.EducationalBackgrounds.Queries
{
    internal class GetEducationalBackgroundsQueryHandler : IRequestHandler<GetEducationalBackgroundsQuery, OperationResult<List<EducationalBackground>>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetEducationalBackgroundsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<EducationalBackground>>> Handle(GetEducationalBackgroundsQuery request, CancellationToken cancellationToken)
        {

            var educationalBackgrounds = await _unitOfWork.ReadEducationalBackgroundRepository.GetAllAsync();

            if (educationalBackgrounds is not null)
                return OperationResult<List<EducationalBackground>>.SuccessResult(educationalBackgrounds);

            return OperationResult<List<EducationalBackground>>.FailureResult("There is no educationalBackgrounds !!!");
        }

       
    }
}