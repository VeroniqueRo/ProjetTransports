using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TransportsLibrary;

namespace ProjetTransports
{
    class Program
    {

        static void Main(string[] args)
        {

            // Définition des éléments de position de la CCI
            string longitude = "5.724524";
            string latitude = "45.188529";
            int distance = 400; // Périmètre de recherche autour de la CCI



            // Instance de connexion avec l'API des LIGNES DE TRANSPORT A PROXIMITE D'UN POINT
            Connexion connectStations = new Connexion();
            String responseFromServer1 = connectStations.ConnexionApi("http://data.metromobilite.fr/api/linesNear/json?x=" + longitude + "&y=" + latitude + "&dist=" + distance + "&details=true");
            // Convertit le flux json en collection d'objets C# BusStationObject
            List<BusStationObject> busStations = JsonConvert.DeserializeObject<List<BusStationObject>>(responseFromServer1);
            // Crée un dictionnaire et retire les doublons
            Dictionary<string, List<string>> dicoStation = ToolBox.dicoCreateAndClean(busStations);



            // Instance de connexion avec l'API des LIGNES DE TRANSPORT
            Connexion connectLignes = new Connexion();
            String responseFromServer2 = connectLignes.ConnexionApi("http://data.metromobilite.fr/api/routers/default/index/routes");
            // Convertit le flux json en collection d'objets C# LineDetails
            List<LineDetails> detailLignes = JsonConvert.DeserializeObject<List<LineDetails>>(responseFromServer2);
            
            Console.WriteLine("Liste des transports de l'aglomération autour de la CCI :" + "\n");

            //affichage du dictionnaire
            foreach (KeyValuePair<string, List<string>> kvp in dicoStation)
            {
                Console.WriteLine("*****************************************************************");
                Console.WriteLine("  Arret = " + kvp.Key);
                Console.WriteLine("*****************************************************************\n");
                foreach (string line in kvp.Value)
                {
                    //int delimiter = line.IndexOf(":");
                    //Console.WriteLine("      Ligne = " + line.Substring(delimiter + 1));
                    foreach (LineDetails linedetail in detailLignes)
                    {
                        if (linedetail.id.Contains(line))
                        {
                            Console.WriteLine("      Ligne  = " + linedetail.shortName);
                            Console.WriteLine("      Nom  = " + linedetail.longName);
                            Console.WriteLine("      Couleur  = " + linedetail.color +"\n");
                        }
                    }

                }
                   
            }
                    
        }

     }

}
