using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportsLibrary
{
    //Constructeur concernant le détail des lignes
    public class LineDetailsObject
    {
            public string id { get; set; }
            public string shortName { get; set; }
            public string longName { get; set; }
            public string color { get; set; }
            public string textColor { get; set; }
            public string mode { get; set; }
            public string type { get; set; }
    }
}
