using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TransportsLibrary
{
    public class Connexion : IConnexionApi
    {
        // Méthode pour se connecter à une API et retourner des données Json
        public String ConnexionApi(string url)
        {
            // Pour éviter les erreurs de communication
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            WebRequest request = null;
            WebResponse response = null;
            Stream dataStream = null;
            StreamReader reader = null;
            String responseFromServer = null;

            try
            {
                // Crée une requête utilisant la classe WebRequest pour afficher toutes les lignes de transport à proximité d'un lieu   
                request = WebRequest.Create(url);
                // If required by the server, set the credentials.  
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.  
                response = request.GetResponse();
                // Display the status.  
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.  
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.  
                reader = new StreamReader(dataStream);
                // Lit le contenu du flux.  
                responseFromServer = reader.ReadToEnd();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            finally
            {
                // Ferme les différentes connexions
                reader.Close();
                response.Close();
            }

            return responseFromServer;
        }
    }
}
