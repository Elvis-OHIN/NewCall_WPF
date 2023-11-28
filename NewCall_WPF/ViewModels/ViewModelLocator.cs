using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCall_WPF.ViewModels
{
    public static class ViewModelLocator
    {
        private static MainViewModel _mainViewModel = new MainViewModel();
        private static StudentViewModel _studentViewModel = new StudentViewModel();
        public static MainViewModel MainViewModelInstance => MainViewModel.Instance;
        public static MainViewModel MainViewModel => _mainViewModel;
        public static StudentViewModel StudentViewModel => _studentViewModel;
    }
}
