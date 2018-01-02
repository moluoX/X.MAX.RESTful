using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace X.MAX.RESTful.Client
{
    public class RESTSerializerJson : IRESTSerializer
    {
        public T Deserialize<T>(string m)
        {
            return JsonConvert.DeserializeObject<T>(m);
        }

        public string Serialize<T>(T m)
        {
            return JsonConvert.SerializeObject(m);
        }
    }
}
