using NewCall_WPF.Models;
using NewCall_WPF.Repositories;
using NewCall_WPF.View;
using NewCall_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewCall_WPF.Modals
{
    /// <summary>
    /// Logique d'interaction pour AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private async void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Students newStudents = new Students
            (
                1,
                TBName.Text,
                Firstname.Text,
                Statut.Text
            );
            StudentsRepository studentsRepository = new StudentsRepository();
            await studentsRepository.AddStudent(newStudents);
            StudentViewModel.Instance.Student = await studentsRepository.GetAllStudent();
            MessageBox.Show("Etudiant ajouté!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
