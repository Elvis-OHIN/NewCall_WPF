using NewCall_WPF.Models;
using NewCall_WPF.ViewModels;
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


namespace NewCall_WPF.View
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
            StudentList.ItemsSource = AbsentViewModel.Instance.Student;
        }
    }
}
