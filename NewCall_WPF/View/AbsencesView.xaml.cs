using NewCall_WPF.Models;
using Newtonsoft.Json;
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


namespace NewCall_WPF
{
    /// <summary>
    /// Logique d'interaction pour AbsencesControl.xaml
    /// </summary>
    public partial class AbsencesView : UserControl
    {
        HttpClient client = new HttpClient();
        public AbsencesView()
        {
            InitializeComponent();
            LoadStudents();
        }

        private async void LoadStudents()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:5164/api/Students/Index");
            
            var jsonString = await response.Content.ReadAsStringAsync();
            var students = JsonConvert.DeserializeObject<List<Students>>(jsonString);
            lvUsers.ItemsSource = students;
        }
    }
}
