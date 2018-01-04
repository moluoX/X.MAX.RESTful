using System;
using System.Collections.Generic;
using System.Text;

namespace X.MAX.RESTful.Client
{
    public class RESTfulClientPool
    {
        static RESTfulClientPool()
        {
            Serializer = new RESTSerializerJson();
            TimeoutMillisecond = 60000;
        }

        public static IRESTSerializer Serializer { get; set; }
        public static int TimeoutMillisecond { get; set; }

        public static IRESTfulClient GetClient(IRESTSerializer serializer = null, int? timeoutMillisecond = null)
        {
            IRESTfulClient client = new RESTfulClientImpl();
            client.Serializer = serializer ?? Serializer;
            client.TimeoutMillisecond = timeoutMillisecond ?? TimeoutMillisecond;
            return client;
        }
    }
}
