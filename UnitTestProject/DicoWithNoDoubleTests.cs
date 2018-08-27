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
    public class DicoWithNoDoubleTests
    {
        
        [TestMethod()]
        public void dicoCreateAndCleanTest()
        {
            // Définition des éléments de position de la CCI
            string longitude = "5.726744267129334";
            string latitude = "45.18521853612248";
            int distance = 400; // Périmètre de recherche autour de la CCI

            DicoWithNoDouble liste = new DicoWithNoDouble(new FakeConnexionApi());
            Dictionary<string, List<string>> result = liste.dicoCreateAndClean(latitude, longitude, distance);
            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(result.ContainsKey("GRENOBLE, CASERNE DE BONNE"));
            Assert.AreEqual(result["GRENOBLE, CASERNE DE BONNE"].Count, 3);
            Assert.AreEqual(result["GRENOBLE, CASERNE DE BONNE"][0], "SEM:13");
            Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"][1].Equals("SEM:16"));
            Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"][2]=="SEM:C4");
        }
    }
}