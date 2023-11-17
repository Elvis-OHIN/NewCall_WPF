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
    /// Logique d'interaction pour HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private DateTime currentDate = DateTime.Now;

        private readonly string[] dayNames = { "Dim", "Lun", "Mar", "Mer", "Jeu", "Ven", "Sam" };

        public HomeView()
        {
            InitializeComponent();
            AddDayHeaders();
            BuildCalendar(currentDate);
        }


        private void AddDayHeaders()
        {
            for (int i = 0; i < dayNames.Length; i++)
            {
                var dayHeader = new TextBlock
                {
                    Text = dayNames[i],
                    Style = (Style)FindResource("DayHeaderStyle"),
                    TextAlignment = TextAlignment.Center
                };

                Grid.SetRow(dayHeader, 0);
                Grid.SetColumn(dayHeader, i);
                CalendarGrid.Children.Add(dayHeader);
            }
        }

        private void BuildCalendar(DateTime date)
        {
            CalendarGrid.Children.Clear(); // Effacer les éléments existants

            // Trouver le premier jour du mois
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            int firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            // Ajouter des boutons pour les jours
            for (int day = 1; day <= daysInMonth; day++)
            {
                var dayButton = new Button
                {
                    Style = (Style)FindResource("DayButtonStyle"),
                    Content = day.ToString()
                };

                int row = (day + firstDayOfWeek - 1) / 7;
                int column = (day + firstDayOfWeek - 1) % 7;

                Grid.SetRow(dayButton, row + 1); // +1 pour la ligne des en-têtes
                Grid.SetColumn(dayButton, column);

                CalendarGrid.Children.Add(dayButton);
            }
        }

    }
}
