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
            //string longitude = "5.726744267129334";
            //string latitude = "45.18521853612248";
            int distance = 400; // Périmètre de recherche autour de la CCI

            // Récupération des données des arrêts et appel de la méthode qui retire les doublons dans le dictionaire
            DataBusStation liste = new DataBusStation(new Connexion());
            Dictionary<string, List<string>> dicoStation = liste.dicoCreateAndClean(latitude, longitude, distance);

            // Récupération des données des lignes
            DataLineDetails dataLineDetails = new DataLineDetails(new Connexion());
            //Console.WriteLine(dataLineDetails.GetLineDetailsObject("SEM:12").color);// test d'affichage depuis l'API des lignes

            //affichage du dictionnaire
            Console.WriteLine("Liste des transports de l'aglomération autour de la CCI :" + "\n");

            foreach (KeyValuePair<string, List<string>> kvp in dicoStation)
            {
                Console.WriteLine("*****************************************************************");
                Console.WriteLine("  Arret = " + kvp.Key);
                Console.WriteLine("*****************************************************************\n");
                foreach (string line in kvp.Value)
                {
                    Console.WriteLine("      Ligne = " + dataLineDetails.GetLineDetailsObject(line).shortName);
                    Console.WriteLine("      Nom  = " + dataLineDetails.GetLineDetailsObject(line).longName);
                    Console.WriteLine("      Couleur  = " + dataLineDetails.GetLineDetailsObject(line).color + "\n");

                    //if (dataLineDetails.GetLineDetailsObject(line).id.Contains(line))
                    //{
                    //    Console.WriteLine("      Ligne  = " + dataLineDetails.GetLineDetailsObject(line).shortName);
                    //    Console.WriteLine("      Nom  = " + dataLineDetails.GetLineDetailsObject(line).longName);
                    //    Console.WriteLine("      Couleur  = " + dataLineDetails.GetLineDetailsObject(line).color + "\n");
                    //}

                }

            }

        }



    }

}
