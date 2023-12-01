using NewCall_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewCall_WPF.ViewModels
{
    class AbsentViewModel : ViewModelBase
    {
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

        private static AbsentViewModel _instance = new AbsentViewModel();
        public static AbsentViewModel Instance => _instance;

        public AbsentViewModel()
        {
          
        }
    }
}
