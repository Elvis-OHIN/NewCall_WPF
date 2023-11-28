using FontAwesome.Sharp;
using HandyControl.Tools.Command;
using NewCall_WPF.Interfaces;
using NewCall_WPF.Models.Calendar;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace NewCall_WPF.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        public ICommand OpenPageCommand { get; private set; }

        private readonly INavigationService _navigationService;

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
        public ICommand ShowCallViewCommand { get; }

        private static CalendarViewModel _instance = new CalendarViewModel();
        public static CalendarViewModel Instance => _instance;
        public CalendarViewModel()
        {
            CurrentMonth = new MonthInfo();
            CurrentMonth.GenerateMonth(DateTime.Now.Year, DateTime.Now.Month);
            ShowCallViewCommand = new ViewModelCommand(ExecuteShowCallViewCommand);
            
        }

        private void ExecuteShowCallViewCommand(object obj)
        {
            var param = obj;
            CallViewModel.Instance.Day = (int)Convert.ToInt64(param); 
            MainViewModel.Instance.CurrentChildView = new CallViewModel();
        }
    }
}

