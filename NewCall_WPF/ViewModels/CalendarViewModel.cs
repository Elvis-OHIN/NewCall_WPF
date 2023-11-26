using FontAwesome.Sharp;
using NewCall_WPF.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace NewCall_WPF.ViewModels
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
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

        public CalendarViewModel()
        {
            CurrentMonth = new MonthInfo();
            CurrentMonth.GenerateMonth(DateTime.Now.Year, DateTime.Now.Month);
            ShowCallViewCommand = new ViewModelCommand(ExecuteShowCallViewCommand);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ExecuteShowCallViewCommand(object obj)
        {
            CurrentChildView = new CallViewModel();
        }
    }
}

