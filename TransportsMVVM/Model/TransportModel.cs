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
            BusStop = key;
            BusLine = value;
        }

        public string BusStop { get; set; }
        public List<string> BusLine { get; set; }
    }
}
