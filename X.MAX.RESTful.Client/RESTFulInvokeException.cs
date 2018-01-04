using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace X.MAX.RESTful.Client
{
    public class RESTFulInvokeException : Exception
    {
        public RESTFulInvokeException()
        {
        }

        public RESTFulInvokeException(string message) : base(message)
        {
        }

        public RESTFulInvokeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RESTFulInvokeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public RESTFulInvokeException(RESTFulInvokeExceptionInfo exceptionInfo) : base(exceptionInfo.message)
        {
            ExceptionInfo = exceptionInfo;
        }

        public RESTFulInvokeExceptionInfo ExceptionInfo { get; set; }

        public override string ToString()
        {
            return ExceptionInfo.ToString() + "\r\n" + base.ToString();
        }
    }
}
