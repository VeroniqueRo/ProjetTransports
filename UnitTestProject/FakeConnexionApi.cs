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
        public String resultatJson { get; set; } // Propriété permettant de gérer les données de Ressource1

        public String ConnexionApi(string url) // Méthode qui implémente celle de l'interface
        {
            return resultatJson;
        }
    }
}
