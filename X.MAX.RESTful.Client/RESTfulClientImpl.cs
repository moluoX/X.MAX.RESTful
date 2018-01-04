using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace X.MAX.RESTful.Client
{
    public class RESTfulClientImpl : IRESTfulClient
    {
        public IRESTSerializer Serializer { get; set; }
        public int TimeoutMillisecond { get; set; }

        public TRes Invoke<TReq, TRes>(TReq req)
        {
            //请求
            string url = Utility.AnalyzeUri(req);
            var request = HttpWebRequest.CreateHttp(url);
            request.Timeout = TimeoutMillisecond;
            request.Method = "POST";

            //body
            var body = Serializer.Serialize(req);
            var bodyBytes = Encoding.UTF8.GetBytes(body);
            request.ContentLength = bodyBytes.LongLength;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bodyBytes, 0, bodyBytes.Length);
                requestStream.Close();
            }

            //回应
            string content;
            int code;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                code = (int)response.StatusCode;
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    content = sr.ReadToEnd();
                }
            }

            RESTFulInvokeExceptionInfo exceptionInfo;
            if (code < 200 || code >= 300)
            {
                if (string.IsNullOrWhiteSpace(content))
                    exceptionInfo = new RESTFulInvokeExceptionInfo { type = "100001", message = "操作失败" };
                exceptionInfo = Serializer.Deserialize<RESTFulInvokeExceptionInfo>(content);
                if (exceptionInfo == null)
                    exceptionInfo = new RESTFulInvokeExceptionInfo { type = "100002", message = "操作失败", messageDetail = content };
                exceptionInfo.url = url;
                exceptionInfo.code = code;

                throw new RESTFulInvokeException(exceptionInfo);
            }

            if (string.IsNullOrWhiteSpace(content))
                return default(TRes);
            var resObj = Serializer.Deserialize<TRes>(content);
            return resObj;
        }
    }
}
