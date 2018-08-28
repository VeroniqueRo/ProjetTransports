using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportsLibrary
{
    public class DataBusStation
    {

        private IConnexionApi connect;

        // Méthode qui retourne une liste à partir du json
        public List<BusStationObject> convertJsonList(string latitude, string longitude, int distance)
        {
            String url = "http://data.metromobilite.fr/api/linesNear/json?x=" + longitude + "&y=" + latitude + "&dist=" + distance + "&details=true";
            String responseFromServer = connect.ConnexionApi(url);
            List<BusStationObject> busStations = JsonConvert.DeserializeObject<List<BusStationObject>>(responseFromServer);
            return busStations;
        }

        // Méthode retirant les doublons dans le dictionaire
        public Dictionary<string, List<string>> dicoCreateAndClean(string latitude, string longitude, int distance)
        {
            List<BusStationObject> busStationsList = convertJsonList(latitude, longitude, distance);
            Dictionary<string, List<string>> dicoStation = new Dictionary<string, List<string>>();

            foreach (BusStationObject station in busStationsList)
            {
                if (!dicoStation.ContainsKey(station.name))
                {
                    dicoStation.Add(station.name, station.lines);
                }
                else
                {
                    //Console.WriteLine("Nb de lignes = " + station.lines.Count);
                    foreach (string line in station.lines)
                    {
                        if (!dicoStation[station.name].Contains(line))
                        {
                            dicoStation[station.name].Add(line);
                        }
                    }
                }

                dicoStation[station.name] = dicoStation[station.name].Distinct().ToList(); // Méthode interne qui retire les doublons des lignes
            }

            return dicoStation;
        }

        // constructeur
        public DataBusStation(IConnexionApi connex)
        {
            connect = connex;
        }
    }
}
