using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TransportsMVVM.ViewModel;

namespace TransportsMVVM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Indispensable à .NET ne pas retirer
            TransportViewModel transportViewModel = new TransportViewModel(); // Instancie un nouveau TransportViewModel
            TransportViewControl.DataContext = transportViewModel; // Lien vers le ViewModel instancié
        }
    }
}
