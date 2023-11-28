using NewCall_WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace NewCall_WPF.Services
{
    public static class ServiceLocator
    {
        private static INavigationService _navigationService;

        public static INavigationService NavigationService
        {
            get
            {
                if (_navigationService == null)
                {
                    var navigationWindow = App.Current.MainWindow as NavigationWindow;
                    _navigationService = new NavigationService(navigationWindow);
                    // Configurez ici les différentes pages
                }
                return _navigationService;
            }
        }
    }

}
