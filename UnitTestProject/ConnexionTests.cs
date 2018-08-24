using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransportsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportsLibrary.Tests
{
    [TestClass()]
    public class ConnexionTests
    {
        [TestMethod()]
        public void ConnexionApiTest()
        {
            string longitude = "5.724524";
            string latitude = "45.188529";
            int distance = 400;

            Connexion target = new Connexion(); // Etant donné une nouvelle connexion
            String result = target.ConnexionApi("http://data.metromobilite.fr/api/linesNear/json?x=" + longitude + "&y=" + latitude + "&dist=" + distance + "&details=true"); // Lorsqu'on appelle l'API
            Assert.AreEqual(string json, result.GetType);// Alors le nom de l'utilistaur de l'ordinateur s'affiche
        }
    }
}