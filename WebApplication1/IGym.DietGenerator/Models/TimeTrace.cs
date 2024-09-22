using IGym.DietGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class TimeTrace
    {
        public int Week { get; set; }
        public DaysOfTheWeek Day { get; set; }
        public string TimeOfDay { get; set; }

        public DateTime DateTime { get; set; }

        public string DayName { get; set; }
    }
}
