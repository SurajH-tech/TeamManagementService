using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Utilities
{
    public class CommandResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }

        public static CommandResult<T> CreateSuccess(T data, int statusCode = 200)
        {
            return new CommandResult<T> { Success = true, Data = data, StatusCode = statusCode };
        }

        public static CommandResult<T> CreateError(string errorMessage, int statusCode)
        {
            return new CommandResult<T> { Success = false, ErrorMessage = errorMessage, StatusCode = statusCode };
        }
    }

    public class CommandResultDto<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public bool IsNull => Data == null;
    }
}
