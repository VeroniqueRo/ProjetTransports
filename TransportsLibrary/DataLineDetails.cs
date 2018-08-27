using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportsLibrary
{
    public class DataLineDetails
    {
        private IConnexionApi connect;

        // Méthode qui retourne un objet LineDetail 
        public LineDetailsObject GetLineDetailsObject (string idLine)
        {
            String url = "http://data.metromobilite.fr/api/routers/default/index/routes?codes="+ idLine;
            String responseFromServer = connect.ConnexionApi(url);
            List<LineDetailsObject> detailsLine = JsonConvert.DeserializeObject<List<LineDetailsObject>>(responseFromServer);

            return detailsLine[0];// Retourne le premier élément de la liste
        }

        // Constructeur
        public DataLineDetails (IConnexionApi connex)
        {
            connect = connex;
        }

    }
}
