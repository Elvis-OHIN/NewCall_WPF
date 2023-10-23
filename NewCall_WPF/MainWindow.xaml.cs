using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using NewCall_WPF.Models;
using NewCall_WPF.View;

namespace NewCall_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = new Login(){

                identifiant = identifiant.Text,
                password = password.Text,

            };
            var reponse = await client.PostAsJsonAsync("http://localhost:5164/api/Admins/login", login);

            if (reponse.IsSuccessStatusCode)
            {
                LoginMessage.Content = "Connexion réussie!";
                DashboardWindow dashboard = new DashboardWindow();
                dashboard.Show();
                this.Close();
            }
            else
            {
                LoginMessage.Content = "Échec de la connexion.";
            }
        }

    }
}
