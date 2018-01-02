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
        }

        public static IRESTSerializer Serializer { get; set; }

        public static IRESTfulClient GetClient(IRESTSerializer serializer = null)
        {
            IRESTfulClient client = new RESTfulClientImpl();
            client.Serializer = serializer ?? Serializer;
            return client;
        }
    }
}
