using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace WorkJwtExampleServer.SharedLibrary.DTOs
{
    public class Response<T> where T : class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        public CustomError Error { get; private set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }


        public static Response<T> Success(T data, int statusCodes)
        {
            return new Response<T> { Data = data, StatusCode = statusCodes, IsSuccessful = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T>() { StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Fail(CustomError customError, int statusCode)
        {
            return new Response<T> { Error = customError, StatusCode = statusCode, IsSuccessful = false };
        }

        public static Response<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            CustomError customError = new(errorMessage, isShow);
            return new Response<T> { Error = customError, IsSuccessful = false, StatusCode = statusCode };
        }
    }
}
