using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTransports
{
    class ToolsBox
    {
        public static Dictionary<string, List<string>> dicoCreateAndClean(List<BusStationObject> busStations)
        {

            Dictionary<string, List<string>> dicoStation = new Dictionary<string, List<string>>();

            foreach (BusStationObject station in busStations)
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
            }

            return dicoStation;
        }
    }
}
