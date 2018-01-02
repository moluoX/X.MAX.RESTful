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

        public TRes Invoke<TReq, TRes>(TReq req)
        {
            try
            {
                string url = Utility.AnalyzeUri(req);
                var request = HttpWebRequest.CreateHttp(url);
                request.Timeout = 10000;
                request.Method = "POST";
                _log.Info(string.Format("[RESTfulClientImpl.Invoke]http请求,{0}", url));

                //回应
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    var code = (int)response.StatusCode;
                    if (code < 200 || code >= 300)
                        throw new Exception(string.Format("http响应{0}", code));

                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        string content = sr.ReadToEnd();
                        if (string.IsNullOrWhiteSpace(content))
                            throw new Exception(string.Format("http响应内容为空"));

                        _log.Info(string.Format("[RESTfulClientImpl.Invoke]http响应{0},{1}\r\n{2}", code, url, content));

                        dynamic resObj = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                        if (resObj.success == true)
                            return resObj.data ?? 0m;
                        else
                            throw new Exception(string.Format("接口返回失败"));
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(string.Format("[RESTfulClientImpl.Invoke]异常,{0}", idCard), ex);
                throw;
            }
        }
    }
}
