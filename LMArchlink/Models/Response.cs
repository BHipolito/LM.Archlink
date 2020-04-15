﻿namespace LMArchlink.Models
{
    public class Response<T>
    {
        public int Code { get; set; }

        public string Msg { get; set; }

        public T Data { get; set; }

        public static Response<T> GetResult(int code, string msg, T data = default(T))
        {
            return new Response<T>
            {
                Code = code,
                Msg = msg,
                Data = data
            };
        }
    }
}
