using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class ADay
    {
        private readonly CultureInfo _cultureInfo;

        public ADay(DateTime date, CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
            Date = date;
            PositionInWeek = (int)date.DayOfWeek;
            Name = setDayName(date);
        }

        public DateTime Date { get; }

        public string Name { get; }

        public int PositionInWeek { get; }

        private string[] getDayNames()
        {
            var dateTimeFormatInfo = _cultureInfo.DateTimeFormat;
            return dateTimeFormatInfo.DayNames;
        }

        private string setDayName(DateTime dayDate)
        {
            string[] dayNames = getDayNames();
            int dayOfWeekCount = (int)dayDate.DayOfWeek;
            return dayNames[dayOfWeekCount];
        }
    }
}
