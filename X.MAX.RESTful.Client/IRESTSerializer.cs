using System;
using System.Collections.Generic;
using System.Text;

namespace X.MAX.RESTful.Client
{
    public interface IRESTSerializer
    {
        string Serialize<T>(T m);
        T Deserialize<T>(string m);
    }
}
