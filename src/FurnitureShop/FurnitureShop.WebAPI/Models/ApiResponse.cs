﻿using FluentValidation.Results;
using System.ComponentModel;
using System.Net;
namespace FurnitureShop.WebApi.Models
{
    public class ApiResponse
    {
        public bool IsSucess => Errors.Count == 0;

        public HttpStatusCode StatusCode { get; init; }
        public IList<string> Errors { get; init; }
        protected ApiResponse() { 
        StatusCode= HttpStatusCode.OK;
            Errors = new List<string>();

        }

        public static ApiResponse<T> Success<T>(
           T result,
           HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ApiResponse<T>
            {
                Result = result,
                StatusCode = statusCode


            };
        }
        public static ApiResponse<T> FailWithResult<T>(
            HttpStatusCode statusCode,
            T result,
            params string[] errorsMessages)
        {
            return new ApiResponse<T>
            {
                Result = result,
                StatusCode = statusCode,

                Errors = new List<string>(errorsMessages)
            };
        }
        public static ApiResponse Fail(HttpStatusCode statusCode,
            params string[] errorMessages)
        {
            if (errorMessages == null || errorMessages.Length == 0)
            {
                throw new ArgumentNullException(nameof(errorMessages));
            }
            return new ApiResponse()
            {
                StatusCode = statusCode,
                Errors = new List<string>(errorMessages)
            };
        }

        public static ApiResponse Fail(HttpStatusCode statusCode, ValidationResult validationResult)
        {
            return Fail(statusCode, validationResult.Errors
                .Select(x => x.ErrorMessage)
                .Where(e => !string.IsNullOrWhiteSpace(e))
                .ToArray());
        }



    }
    public class ApiResponse<T> : ApiResponse
    {
        public T Result { get; set; }
    }


}
