using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportsLibrary;
using TransportsMVVM.Model;

namespace TransportsMVVM.ViewModel
{
    public class TransportViewModel
    {
        public TransportViewModel()
        {
            LoadTransports();
        }

        public ObservableCollection<Transport> Transports
        {
            get;
            set;
        }

        public String PageTitle
        {
            get;
            set;
        }

        public void LoadTransports()
        {

            PageTitle = "TRANSPORTS GRENOBLOIS";

            // Définition des éléments de position de la CCI
            string longitude = "5.724524";
            string latitude = "45.188529";
            int distance = 400; // Périmètre de recherche autour de la CCI

            DataBusStation liste = new DataBusStation(new Connexion());
            Dictionary<string, List<string>> dicoStation = liste.dicoCreateAndClean(latitude, longitude, distance);

            ObservableCollection<Transport> transports = new ObservableCollection<Transport>();
            transports = transformDicoToCollection(dicoStation);

            //transports.Add(new Transport { TableTitle = "LISTE DES ARRETS DE PROXIMITE" });
            //transports.Add(new Transport { BusStation = "CASERNE DE BONNE", Line = "SEM:12" });
            //transports.Add(new Transport { BusStation = "HOTEL DE VILLE", Line = "SEM:C1" });
            //transports.Add(new Transport { BusStation = "VICTOR HUGO", Line = "SEM:16" });

            Transports = transports;
        }

                  
        public ObservableCollection<Transport> transformDicoToCollection(Dictionary<string, List<string>> dico)
        {
            ObservableCollection<Transport> listToReturn = new ObservableCollection<Transport>();
            foreach (KeyValuePair<string, List<string>> kvp in dico)
            {
                Transport transport = new Transport(kvp.Key, kvp.Value);
                listToReturn.Add(transport);
            }

            return listToReturn;
        }
    }
}
