using Application.Models.Area;
using MongoDB.Bson;
using Utils;

namespace Application.Models.Common
{


    public class OperationResult<TResult>
    {
        public TResult Result { get; private set; }

        public bool IsSuccess { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool IsException { get; set; }
        public bool IsNotFound { get; private set; }


        public static OperationResult<TResult> SuccessResult(TResult result)
        {

            var countResult = result.ToJson().ToList();
            if ((countResult.Count == 2 && countResult.First() == '[' && countResult.Last() == ']') || result is null)
                return new OperationResult<TResult> { ErrorMessage = "DataIsNotExist", IsSuccess = false, IsNotFound = true };

            return new OperationResult<TResult> { Result = result, IsSuccess = true };
        }

        public static OperationResult<TResult> FailureResult(string message, TResult result = default)
        {
            return new OperationResult<TResult> { Result = result, ErrorMessage = message, IsSuccess = false };
        }

        public static OperationResult<TResult> NotFoundResult(string message)
        {
            return new OperationResult<TResult> { ErrorMessage = message, IsSuccess = false, IsNotFound = true };
        }

    }
}
