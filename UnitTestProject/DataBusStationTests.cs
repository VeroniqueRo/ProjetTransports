using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransportsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject;

namespace TransportsLibrary.Tests
{
    [TestClass()]
    public class DataBusStationTests
    {
        
        [TestMethod()]
        public void dicoCreateAndCleanTest()
        {
            // Définition des éléments de position de la CCI correspondant aux données de Resource1.JsonProximityLines
            string longitude = "5.726744267129334";
            string latitude = "45.18521853612248";
            int distance = 400;

            FakeConnexionApi fake = new FakeConnexionApi(); // Instancie une nouvelle FakeConnexion
            fake.resultatJson = Resource1.JsonProximityLines; // Récupère les fake données dans les ressources

            DataBusStation liste = new DataBusStation(fake); // Connexion factice avec les données de proximité
            Dictionary<string, List<string>> result = liste.dicoCreateAndClean(latitude, longitude, distance); // Création du dico et nettoyage des doubles
            Assert.AreEqual(result.Count, 1); // Test qu'il n'y a qu'un seul Arrêt
            Assert.IsTrue(result.ContainsKey("GRENOBLE, CASERNE DE BONNE")); // Test sur la clé principale
            Assert.AreEqual(result["GRENOBLE, CASERNE DE BONNE"].Count, 3); // Test sur le nombre de ligne à cet arrêt
            Assert.AreEqual(result["GRENOBLE, CASERNE DE BONNE"][0], "SEM:13"); // Test le nom de la première ligne
            Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"][1].Equals("SEM:16")); // Autre façon d'écrire le même test
            Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"][2]=="SEM:C4"); // Autre façon d'écrire le même test
        }
    }
}