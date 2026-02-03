using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class Response<T> 
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }



        public static Response<T> Ok(T? data, string message = null)
            => new Response<T> { Data = data, Success = true, Message = message };

        public static Response<T> Fail(string message)
            => new Response<T> { Data = default, Success = false, Message = message };
    }
}