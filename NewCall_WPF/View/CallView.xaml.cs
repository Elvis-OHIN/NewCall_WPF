using NewCall_WPF.Models;
using NewCall_WPF.Repositories;
using NewCall_WPF.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace NewCall_WPF.View
{
    /// <summary>
    /// Logique d'interaction pour CallView.xaml
    /// </summary>
    public partial class CallView : UserControl
    {
        HttpClient client = new HttpClient();
        public CallView()
        {
            InitializeComponent();
            LoadStudents();
        }
        private async void LoadStudents()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:5164/api/Students/Index");

            var jsonString = await response.Content.ReadAsStringAsync();
            var students = JsonConvert.DeserializeObject<List<Students>>(jsonString);
            StudentList.ItemsSource = students;
        }
        private void btnEnregistrerSelection_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = new DateTime(CalendarViewModel.Instance.CurrentMonth.Year, CalendarViewModel.Instance.CurrentMonth.Month,CallViewModel.Instance.Day);
            var personnesSelectionnees = StudentList.Items
                .OfType<Students>()
                .Where(p => p.IsSelect)
            .Select(p => p.id)
                .ToList();

            AbsenceRepository absenceRepository = new AbsenceRepository();
            foreach (var item in personnesSelectionnees)
            {
                Absences absences = new Absences();
                absences.startDate = date;
                absences.studentId = item;
                absenceRepository.AddAbsence(absences);
            }
            MainViewModel.Instance.CurrentChildView = new CalendarViewModel();
        }
    }
}
