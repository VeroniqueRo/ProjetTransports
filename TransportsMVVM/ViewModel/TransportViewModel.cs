using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportsLibrary;
using TransportsMVVM.Model;

namespace TransportsMVVM.ViewModel
{
    public class TransportViewModel : INotifyPropertyChanged
    {
        // Déclaration des attributs
        private String longitude;
        private String latitude;
        private int distance;
        private String pageTitle;
        private ObservableCollection<Transport> transports;

        // Constructeur
        public TransportViewModel()
        {
            PageTitle = "TRANSPORTS GRENOBLOIS";
            // Définition des éléments de position de la CCI par défaut
            longitude = "5.724524";
            latitude = "45.188529";
            distance = 400; // Périmètre de recherche autour de la CCI
            LoadTransports();
        }

        // Properties
        public ObservableCollection<Transport> Transports
        {
            get
            {
                return transports;
            }
            set
            {
                if (transports != value)
                {
                    transports = value;
                    RaisePropertyChanged("Transports");
                }

            }
        }

        public string PageTitle
        {
            get
            {
                return pageTitle;
            }
            set
            {
                if (pageTitle != value)
                {
                    pageTitle = value;
                    RaisePropertyChanged("PageTitle");
                }

            }
        }

        public string Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                if (longitude != value)
                {
                    longitude = value;
                    LoadTransports();
                    RaisePropertyChanged("Longitude");
                }

            }
        }

        public string Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                if (latitude != value)
                {
                    latitude = value;
                    LoadTransports();
                    RaisePropertyChanged("Latitude");
                }

            }
        }

        public int Distance
        {
            get
            {
                return distance;
            }

            set
            {
                if (distance != value)
                {
                    distance = value;
                    LoadTransports();
                    RaisePropertyChanged("Distance");
                }

            }
        }

        public void LoadTransports()
        {




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


        
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property) // Méthode outil pour faire les changement dans la vue
        {
            if (PropertyChanged != null) // Condition pour que l'évenement soit déclanché que si il existe des abonnés
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
