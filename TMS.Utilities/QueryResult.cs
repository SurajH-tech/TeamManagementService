using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Utilities
{
    public class QueryResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }

        public static QueryResult<T> CreateSuccess(T data, int statusCode = 200)
        {
            return new QueryResult<T> { Success = true, Data = data, StatusCode = statusCode };
        }

        public static QueryResult<T> CreateError(string errorMessage, int statusCode)
        {
            return new QueryResult<T> { Success = false, ErrorMessage = errorMessage, StatusCode = statusCode };
        }
    }

    public class QueryResultDto<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public bool IsNull => Data == null;
    }
}
