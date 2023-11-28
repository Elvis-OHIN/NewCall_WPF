using HandyControl.Tools.Command;
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

        public event Action<string> RequestViewChange;

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
