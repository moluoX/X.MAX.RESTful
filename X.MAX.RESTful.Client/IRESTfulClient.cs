using System;

namespace X.MAX.RESTful.Client
{
    public interface IRESTfulClient//<in TReq, out TRes>
    {
        TRes Invoke<TReq, TRes>(TReq req);
        IRESTSerializer Serializer { get; set; }
        int TimeoutMillisecond { get; set; }
    }
}
