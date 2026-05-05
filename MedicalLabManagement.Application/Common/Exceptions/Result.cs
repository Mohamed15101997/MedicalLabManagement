namespace MedicalLabManagement.Application.Common.Exceptions
{
	public class Result
	{
		public bool IsSuccess { get; }
		public Error Error { get; } = default!;
		public bool IsFailure => !IsSuccess;
		public Result(bool isSuccess, Error error)
		{
			if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
				throw new InvalidOperationException();

			IsSuccess = isSuccess;
			Error = error;
		}
		public static Result Success() => new Result(true, Error.None);
		public static Result Failure(Error error) => new Result(false, error);
	}
	public class Result<T> : Result
	{
		public T Response { get;}
		public Result(T response, bool isSuccess , Error error) : base(isSuccess , error)
		{
			Response = response;
		}
		public static Result<T> Success(T data) => new Result<T>(data,true, Error.None);
		public static new Result<T> Failure(Error error) => new (default,false, error);
		public static  Result<T> Failure(T data,Error error) => new (data,false, error);

	}
}
