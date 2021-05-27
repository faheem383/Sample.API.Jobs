using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Jobs
{
    public class CustomException : ArgumentException
    {
        public int ErrorCode { get; }
        public CustomException(string paramName, int errorCode)
            : base(paramName)
        {
            ErrorCode = errorCode;
        }
    }
}
