using System;
using System.Collections.Generic;
using System.Text;

namespace X.MAX.RESTful.Client
{
    public class RESTFulInvokeExceptionInfo
    {
        public string url { get; set; }
        public int code { get; set; }

        public string type { get; set; }
        public string message { get; set; }
        public string messageDetail { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("{");
            if (url != null)
                sb.Append(string.Format("\"url\":\"{0}\",", url));
            sb.Append(string.Format("\"code\":{0},", code));
            if (type != null)
                sb.Append(string.Format("\"type\":\"{0}\",", type));
            if (message != null)
                sb.Append(string.Format("\"message\":\"{0}\",", message));
            if (messageDetail != null)
                sb.Append(string.Format("\"messageDetail\":\"{0}\",", messageDetail));
            sb.Append("}");
            return sb.ToString();
        }
    }
}
