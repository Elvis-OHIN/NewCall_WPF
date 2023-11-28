using NewCall_WPF.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCall_WPF.ViewModels
{
    class CallViewModel : ViewModelBase
    {
        private int  _day;

        public int Day
        {
            get => _day;
            set
            {
                if (_day != value)
                {
                    _day = value;
                    OnPropertyChanged(nameof(Day));
                }
            }
        }
        private static CallViewModel _instance = new CallViewModel();
        public static CallViewModel Instance => _instance;
        public CallViewModel()
        {
            

        }
    }
}
