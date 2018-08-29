using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportsMVVM.Model
{

    public class TranportModel  {  }

    public class Transport
    {
        public Transport(string key, List<string> value)
        {
            Key = key;
            Value = value;
        }

        public String TableTitle { get; set; }
        public String BusStation { get; set; }
        public String Line { get; set; }
        public string Key { get; set; }
        public List<string> Value { get; set; }
    }

}
