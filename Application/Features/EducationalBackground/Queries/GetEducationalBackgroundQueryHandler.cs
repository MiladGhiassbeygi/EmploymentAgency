using Application.Contracts.Persistence;
using Application.Models.Common;
using Domain.ReadModel;
using MediatR;

namespace Application.Features.EducationalBackgrounds.Queries
{
    internal class GetEducationalBackgroundQueryHandler : IRequestHandler<GetEducationalBackgroundQuery, OperationResult<EducationalBackground>>
    {

        readonly IUnitOfWork _unitOfWork;

        public GetEducationalBackgroundQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<EducationalBackground>> Handle(GetEducationalBackgroundQuery request, CancellationToken cancellationToken)
        {

            var educationalbackground = await _unitOfWork.ReadEducationalBackgroundRepository.FirstOrDefaultAsync(x=> x.JobSeekerId == request.Id);

            if (educationalbackground is not null)
                return OperationResult<EducationalBackground>.SuccessResult(educationalbackground);

            return OperationResult<EducationalBackground>.FailureResult("There is no EducationalBackground !!!");
        }

       
    }
}