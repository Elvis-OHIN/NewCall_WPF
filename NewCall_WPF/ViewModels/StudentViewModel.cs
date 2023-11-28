using HandyControl.Tools.Command;
using NewCall_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewCall_WPF.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        public ICommand ChangeViewCommand { get; private set; }

        

        public ICommand ShowCalendarViewCommand { get; }

        private List<Students> _student;
        public List<Students> Student
        {
            get
            {
                return _student;
            }

            set
            {
                _student = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        private static StudentViewModel _instance = new StudentViewModel();
        public static StudentViewModel Instance => _instance;

        public StudentViewModel()
        {
            ChangeViewCommand = new ViewModelCommand(ExecuteChangeViewCommand);
     
        }

        private void ExecuteChangeViewCommand(object obj)
        {
            MainViewModel.Instance.CurrentChildView = new HomeViewModel();
        }

    }
}
