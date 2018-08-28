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
    public class DataLineDetailsTests
    {
        [TestMethod()]
        public void GetLineDetailsObjectTest()
        {
            FakeConnexionApi fake = new FakeConnexionApi(); // Instancie une nouvelle FakeConnexion
            fake.resultatJson = Resource1.JsonDetailLine; // Récupère les fake données dans les ressources

            DataLineDetails dataLineDetails = new DataLineDetails(fake); // Connexion factice avec les données d'une ligne
            LineDetailsObject resultat = dataLineDetails.GetLineDetailsObject("SEM:12"); // Crée la liste correspondant à la ligne SEM:12
            Assert.AreEqual(resultat.shortName, "12"); // Test si le nom court est 12
            Assert.IsTrue(resultat.color.Contains("009930")); // Test la couleur
            Assert.IsTrue(resultat.longName.Contains("Eybens Maisons Neuves")); // Test le nom complet de la ligne
        }
    }
}