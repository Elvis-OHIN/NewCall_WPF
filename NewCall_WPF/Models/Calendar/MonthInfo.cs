using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCall_WPF.Models.Calendar
{
    public class MonthInfo
    {
        public int Year { get; private set; }
        public int Month { get; private set; }

        public string NameMonth { get; private set; }
        public ObservableCollection<WeekInfo> Weeks { get; private set; }

        public MonthInfo()
        {
            Weeks = new ObservableCollection<WeekInfo>();
        }

        public void GenerateMonth(int year, int month)
        {
            Year = year;
            Month = month;
            NameMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
            Weeks.Clear();

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);


            int daysToSubtract = ((int)firstDayOfMonth.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            DateTime currentDay = firstDayOfMonth.AddDays(-daysToSubtract);

            while (currentDay.Month <= month || currentDay.DayOfWeek != DayOfWeek.Monday)
            {
                if(currentDay.Year != year)
                {
                    break;
                }
                WeekInfo week = new WeekInfo();

                for (int i = 0; i < 7 && (currentDay.Month <= month || currentDay.DayOfWeek != DayOfWeek.Monday); i++)
                {
                    if (currentDay.DayOfWeek != DayOfWeek.Saturday && currentDay.DayOfWeek != DayOfWeek.Sunday && currentDay.Month == month)
                    {
                        week.SetDayInfo(currentDay.DayOfWeek, new DayInfo { DayNumber = currentDay.Day.ToString() });
                    }
                    currentDay = currentDay.AddDays(1);
                }
                if (week.HasNullProperties())
                {
                    Weeks.Add(week);
                }
            }
        }
    }
}
