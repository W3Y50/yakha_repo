using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client.Hubs;
using ClassLibrary;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SharedDataModel _sharedData;

        public MainWindow(SharedDataModel sharedData)
        {
            _sharedData = sharedData;
            InitializeComponent();
            


        }

        private void derButton_Click(object sender, RoutedEventArgs e)
        {

            Console.WriteLine(_sharedData._seismicEvents);
        }

    }

}