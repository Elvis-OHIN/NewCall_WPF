﻿using NewCall_WPF.Modals;
using NewCall_WPF.Repositories;
using NewCall_WPF.ViewModels;
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

namespace NewCall_WPF.View
{
    /// <summary>
    /// Logique d'interaction pour StudentView.xaml
    /// </summary>
    public partial class StudentView : UserControl
    {
        public StudentView()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addStudent= new AddStudent();
            addStudent.ShowDialog();
        }

        private async void LoadStudents()
        {
            StudentsRepository studentsRepository = new StudentsRepository();
            StudentViewModel.Instance.Student = await studentsRepository.GetAllStudent();
            StudentList.ItemsSource = StudentViewModel.Instance.Student;
        }
    }
}
