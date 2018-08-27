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
            string longitude = "5.726744267129334";
            string latitude = "45.18521853612248";
            int distance = 400; // Périmètre de recherche autour de la CCI

            // Appel de la méthode qui retire les doublons dans le dictionaire
            DicoWithNoDouble liste = new DicoWithNoDouble(new Connexion());
            Dictionary<string, List<string>> dicoStation = liste.dicoCreateAndClean(latitude, longitude, distance);

            // Instance de connexion avec l'API des LIGNES DE TRANSPORT
            Connexion connectLignes = new Connexion();
            String urlLignes = "http://data.metromobilite.fr/api/routers/default/index/routes";
            // Convertit le flux json en collection d'objets C# LineDetails
            List<LineDetails> detailLignes = JsonConvert.DeserializeObject<List<LineDetails>>(connectLignes.ConnexionApi(urlLignes));

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
