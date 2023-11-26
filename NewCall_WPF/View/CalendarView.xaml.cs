using NewCall_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewCall_WPF.View
{
    /// <summary>
    /// Logique d'interaction pour CalendarView.xaml
    /// </summary>
    public partial class CalendarView : UserControl
    {
        public CalendarView()
        {
            InitializeComponent();
           
        }

        private void OnPreviousMonthClicked(object sender, RoutedEventArgs e)
        {
            ChangeMonth(-1);
        }

        private void OnNextMonthClicked(object sender, RoutedEventArgs e)
        {
            ChangeMonth(1);
        }

        private void ChangeMonth(int monthsToAdd)
        {
            var currentMonth = ((CalendarViewModel)this.DataContext).CurrentMonth;
            var MonthName = ((CalendarViewModel)this.DataContext).CurrentMonth;
            DateTime newMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1).AddMonths(monthsToAdd);
            currentMonth.GenerateMonth(newMonth.Year, newMonth.Month);
            Month.Content = MonthName.NameMonth;
        }

        private void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(CalendarData);
            var hitTestResult = VisualTreeHelper.HitTest(CalendarData, point);
            if (hitTestResult != null)
            {
                var cell = FindParent<DataGridCell>(hitTestResult.VisualHit);
                if (cell != null)
                {
                    var content = cell.Content as TextBlock;
                    if (content != null)
                    {
                        string cellValue = content.Text;
                        DataContext = new MainViewModel();
                        var viewModel = DataContext as MainViewModel;
                        
                    }
                }
            }
        }

        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentDepObj = VisualTreeHelper.GetParent(child);
            if (parentDepObj == null) return null;

            T parent = parentDepObj as T;
            if (parent != null) return parent;
            else return FindParent<T>(parentDepObj);
        }
    }
}
