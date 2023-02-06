using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inta.Turizm.Logging.Serializer
{
    public class JavaScript<T>
    {
        internal string Serializer(T obj)
        {
            string val = string.Empty;
            val = JsonConvert.SerializeObject(obj);
            return val;
        }

        internal T Deserialize(string val)
        {
            var obj = JsonConvert.DeserializeObject<T>(val);
            return obj;
        }

    }
}
