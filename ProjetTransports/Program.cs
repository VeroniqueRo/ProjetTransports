using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjetTransports
{
    class Program
    {

        static void Main(string[] args)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            WebRequest request = null;
            WebResponse response = null;
            Stream dataStream = null;
            StreamReader reader = null;
            string longitude = "5.724524";
            string latitude = "45.188529";
            int distance = 400;

            try
            {

                // Crée une requête utilisant la classe WebRequest pour afficher toutes les lignes de transport à proximité d'un lieu   
                request = WebRequest.Create("http://data.metromobilite.fr/api/linesNear/json?x=" + longitude + "&y=" + latitude + "&dist=" + distance + "&details=true");
               
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
                string responseFromServer = reader.ReadToEnd();

                // Affiche le flux json.  
                //Console.WriteLine(responseFromServer);

                // Convertit le flux json en collection d'objets C# BusStationObject
                List<BusStationObject> busStations = JsonConvert.DeserializeObject<List<BusStationObject>>(responseFromServer);


                //ProjetTransports.Factory.dicoCreateAndClean(List<BusStationObject> busStations);

                // Crée un dictionnaire
                Dictionary<string, List<string>> dicoStation = new Dictionary<string, List<string>>();

                // Parcoure la collection d'objets pour créer un dictionary
                foreach (BusStationObject station in busStations)
                {
                    // Si la clé de l'arrêt n'existe pas
                    if (!dicoStation.ContainsKey(station.name))
                    {
                        // Ajoute la clé et la liste associée dans le dictionaire
                        dicoStation.Add(station.name, station.lines);
                    }
                    else
                    {
                        //Console.WriteLine("Nb de lignes = " + station.lines.Count);

                        foreach (string line in station.lines)
                        {
                            // Si les lignes de bus correspondantes à la clé Arrêt n'existent pas
                            if (!dicoStation[station.name].Contains(line))
                            {
                                // Ajoute les lignes de bus dans le doictionnaire
                                dicoStation[station.name].Add(line);
                            }

                        }
                    }
                }

                //affichage du dictionnaire
                foreach (KeyValuePair<string, List<string>> kvp in dicoStation)
                {
                    Console.WriteLine("Arret = " + kvp.Key);
                    foreach (string line in kvp.Value)
                    {
                        int delimiter = line.IndexOf(":");
                        Console.WriteLine("      Ligne = " + line.Substring(delimiter + 1));
                    }

                    //    //Console.WriteLine("Nom de la station : " + station.name + "\n");
                    //    ////Console.WriteLine("GPS Longitude : " + station.lon + " et Latitude : " + station.lat);

                    //    //foreach (string line in station.lines)
                    //    //{
                    //    //    int delimiter = line.IndexOf(":");
                    //    //    Console.WriteLine("Nom de la ligne : " + line.Substring(delimiter + 1));
                    //    //}

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            finally
            {
                // Clean up the streams and the response. 
                reader.Close();
                response.Close();
            }
            
        }

        

    }


}
