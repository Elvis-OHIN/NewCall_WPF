using FontAwesome.Sharp;
using HandyControl.Tools.Command;
using NewCall_WPF.Interfaces;
using NewCall_WPF.Models;
using NewCall_WPF.Models.Calendar;
using NewCall_WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace NewCall_WPF.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {


        private static CalendarViewModel _instance = new CalendarViewModel();
        public static CalendarViewModel Instance => _instance;

        private MonthInfo _currentMonth;

        public MonthInfo CurrentMonth
        {
            get => _currentMonth;
            set
            {
                if (_currentMonth != value)
                {
                    _currentMonth = value;
                    OnPropertyChanged(nameof(CurrentMonth));
                }
            }
        }
        private ViewModelBase _currentChildView;
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

        private bool _viewAbsences;
        public bool ViewAbsences
        {
            get
            {
                return _viewAbsences;
            }

            set
            {
                _viewAbsences = value;
                OnPropertyChanged(nameof(ViewAbsences));
            }
        }
        public ICommand ShowCallViewCommand { get; }

        public ICommand ShowAbsenceViewCommand { get; private set; }

        public CalendarViewModel()
        {
            CurrentMonth = new MonthInfo();
            CurrentMonth.GenerateMonth(DateTime.Now.Year, DateTime.Now.Month);
            ShowCallViewCommand = new ViewModelCommand(ExecuteShowCallViewCommand);
            ShowAbsenceViewCommand = new ViewModelCommand(ExecuteShowAbsenceViewCommand);
        }

        private void ExecuteShowCallViewCommand(object obj)
        {
            var param = obj;
            CallViewModel.Instance.Day = (int)Convert.ToInt64(param);
            DateTime date = new DateTime(CurrentMonth.Year, CurrentMonth.Month, (int)Convert.ToInt64(param));
            MainViewModel.Instance.Caption += $" / Faire l'appel pour le {date.ToString("dd MMMM yyyy")}";
            MainViewModel.Instance.CurrentChildView = new CallViewModel();
        }

        private async void ExecuteShowAbsenceViewCommand(object obj)
        {
            var param = obj;
            DateTime date = new DateTime(CurrentMonth.Year, CurrentMonth.Month, (int)Convert.ToInt64(param));
            AbsenceRepository absenceRepository = new AbsenceRepository();
            var absences = await absenceRepository.GetAbsenceByDate(date);

            AbsentViewModel.Instance.Student = absences;

            if (absences.Count > 0)
            {
                StudentViewModel.Instance.Student = absences;
                MainViewModel.Instance.Caption += $" / Liste des absents du {date.ToString("dd MMMM yyyy")}";
                MainViewModel.Instance.CurrentChildView = new AbsentViewModel();
            }
        }
    }
}

