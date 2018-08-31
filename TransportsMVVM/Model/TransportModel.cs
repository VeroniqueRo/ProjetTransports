using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportsMVVM.Model
{

    public class TranportModel  {  }

    public class Transport : INotifyPropertyChanged
    {
        
        public Transport(string key, List<string> value)
        {
            BusStop = key;
            BusLine = value;
        }

        public string BusStop { get; set; }
        public List<string> BusLine { get; set; }
    
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
