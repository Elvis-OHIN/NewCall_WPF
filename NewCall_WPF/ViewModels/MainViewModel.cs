using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewCall_WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private static MainViewModel _instance = new MainViewModel();
        public static MainViewModel Instance => _instance;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowStudentViewCommand { get; }
        public ICommand ShowCalendarViewCommand { get; }

        public ICommand ShowCalendarAbsencesViewCommand { get; }

   
        public MainViewModel()
        {
            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowStudentViewCommand = new ViewModelCommand(ExecuteShowStudentViewCommand);
            ShowCalendarViewCommand = new ViewModelCommand(ExecuteShowCalendarViewCommand);
            ShowCalendarAbsencesViewCommand = new ViewModelCommand(ExecuteShowCalendarAbsencesViewCommand);
            //Default view
            ExecuteShowHomeViewCommand(null);

        }
      
        private void ExecuteShowStudentViewCommand(object obj)
        {
            CurrentChildView = new StudentViewModel();
            Caption = "Etudiants";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }
        private void ExecuteShowCalendarViewCommand(object obj)
        {
            CurrentChildView = new CalendarViewModel();
            CalendarViewModel.Instance.ViewAbsences = false;
            Caption = "Feuille d'appel";
            Icon = IconChar.Newspaper;
        }

        private void ExecuteShowCalendarAbsencesViewCommand(object obj)
        {
            CurrentChildView = new CalendarViewModel();
            CalendarViewModel.Instance.ViewAbsences = true;
            Caption = "Liste des absences";
            Icon = IconChar.UsersSlash;
        }

    }
}
