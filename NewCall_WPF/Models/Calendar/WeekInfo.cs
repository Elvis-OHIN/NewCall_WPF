using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCall_WPF.Models.Calendar
{
    public class WeekInfo
    {
        public DayInfo Monday { get; set; }
        public DayInfo Tuesday { get; set; }
        public DayInfo Wednesday { get; set; }
        public DayInfo Thursday { get; set; }
        public DayInfo Friday { get; set; }

        public void SetDayInfo(DayOfWeek dayOfWeek, DayInfo dayInfo)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday: Monday = dayInfo; break;
                case DayOfWeek.Tuesday: Tuesday = dayInfo; break;
                case DayOfWeek.Wednesday: Wednesday = dayInfo; break;
                case DayOfWeek.Thursday: Thursday = dayInfo; break;
                case DayOfWeek.Friday: Friday = dayInfo; break;
            }
        }
        public bool HasNullProperties()
        {
            var type = GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(this) != null)
                {
                    return true; 
                }
            }
            return false;
        }
    }

}
