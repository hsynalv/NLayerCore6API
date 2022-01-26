using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static CustomResponseDto<T> Success(int statusCode, T data) 
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };
        }
    }

    public class CustomNoContentDto
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static CustomNoContentDto Success(int statusCode)
        {
            return new CustomNoContentDto { StatusCode = statusCode };
        }

        public static CustomNoContentDto Fail(int statusCode, List<string> errors)
        {
            return new CustomNoContentDto { StatusCode = statusCode, Errors = errors };
        }

        public static CustomNoContentDto Fail(int statusCode, string error)
        {
            return new CustomNoContentDto { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
