using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject;

namespace TransportsLibrary
{
    class FakeConnexionApi : IConnexionApi
    {
        public string ConnexionApi(string url)
        {
            return Resource1.JsonProximityLines;
        }
    }
}
