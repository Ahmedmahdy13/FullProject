using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationFailure = FluentValidation.Results.ValidationFailure;
namespace Application.Shared
{
	public class Result<T>
	{
		public bool Succeeded { get; set; }
		public StatusResult StatusResult { get; set; }
		public int? StatusCode { get; set; }
		public string? Message { get; set; }
		public T? Data { get; set; }

		public List<ValidationFailure>? ValidationsErrors { get; set; }
		public Result() { }

		public Result(bool succeeded , StatusResult statusResult)
		{
			succeeded = Succeeded;
			statusResult = StatusResult;
		}

		public static Result<T> Success(T Data , string Message = "Success")
		{
			return new Result<T>()
			{
				Succeeded = true,
				StatusResult = StatusResult.Success,
				StatusCode = (int)StatusCodes.Status200OK,
				Data = Data,
				Message = Message
			};
		}

		public static Result<T> Faild(T Data , string Message = "Faild")
		{
			return new Result<T>()
			{
				Succeeded = false,
				StatusResult = StatusResult.Faild,
				StatusCode = (int)StatusCodes.Status417ExpectationFailed,
				Data = Data,
				Message = Message
				
			};
		}

		public static Result<T> Info(T Data , StatusResult statusResult = StatusResult.Exist , string Message = "Exist" , int statusCode = (int)StatusCodes.Status200OK)
		{
			return new Result<T>()
			{
				Succeeded = false,
				StatusResult = statusResult,
				StatusCode = statusCode,
				Data = Data,
				Message = Message
			};
		}


	}


	public class Result
	{
		public bool Succeeded { get; set; }
		public StatusResult StatusResult { get; set; }
		public int? StatusCode { get; set; }
		public string? Message { get; set; }
		public List<ValidationFailure>? ValidationsErrors { get; set; }

		public static Result Success(string Message = "Success")
		{
			return new Result()
			{
				Succeeded = true,
				StatusResult = StatusResult.Success,
				StatusCode = StatusCodes.Status200OK,
				Message = Message
			};
		}

		public static Result Faild(string Message = "Faild")
		{
			return new Result()
			{
				Succeeded = false,
				StatusResult = StatusResult.Faild,
				StatusCode = StatusCodes.Status417ExpectationFailed,
				Message = Message
			};
		}

		public static Result Info(StatusResult statusResult = StatusResult.Exist , string Message = "Exist" , int statusCode = (int)StatusCodes.Status200OK)
		{
			return new Result()
			{
				Succeeded = false,
				StatusResult = statusResult,
				StatusCode = statusCode,
				Message = Message
			};
		}
	}
}
