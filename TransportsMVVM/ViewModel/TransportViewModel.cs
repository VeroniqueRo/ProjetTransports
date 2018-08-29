using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public String Title
        {
            get;
            set;
        }

        public void LoadTransports()
        {

            Title = "Liste des arrêts de bus";

            ObservableCollection<Transport> transports = new ObservableCollection<Transport>();

            transports.Add(new Transport { BusStation = "CASERNE DE BONNE", Line = "SEM:12" });
            transports.Add(new Transport { BusStation = "HOTEL DE VILLE", Line = "SEM:C1" });
            transports.Add(new Transport { BusStation = "VICTOR HUGO", Line = "SEM:16" });

            Transports = transports;
        }
    }
}
