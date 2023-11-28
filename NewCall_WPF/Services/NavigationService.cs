using NewCall_WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NewCall_WPF.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<string, Uri> _pagesByKey = new Dictionary<string, Uri>();
        private NavigationWindow _navigationWindow;

        public NavigationService(NavigationWindow navigationWindow)
        {
            _navigationWindow = navigationWindow;
        }

        public void NavigateTo(string pageKey)
        {
            if (_pagesByKey.ContainsKey(pageKey))
            {
                var frame = _navigationWindow.Content as Frame;
                frame?.Navigate(_pagesByKey[pageKey]);
            }
        }

        public void GoBack()
        {
            var frame = _navigationWindow.Content as Frame;
            if (frame != null && frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        public void Configure(string key, Uri pageType)
        {
            if (_pagesByKey.ContainsKey(key))
            {
                _pagesByKey[key] = pageType;
            }
            else
            {
                _pagesByKey.Add(key, pageType);
            }
        }
    }

}
