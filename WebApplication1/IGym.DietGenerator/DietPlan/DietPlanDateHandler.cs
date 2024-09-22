using IGym.DietGenerator.Builders;
using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Models.Values;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace IGym.DietGenerator.DietPlan
{
    public class DietPlanDateHandler
    {
        private readonly CultureInfo _cultureInfo;

        public DietPlanDateHandler(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
        }

        public void Set(List<DailyDietPlan> dailyDietPlan, DietStartDay startDay) 
        {
            for (int i = 0; i < dailyDietPlan.Count; i++) 
            {
                DateTime date = startDay.Value.AddDays(i);
                string dayName = setDayName(date);
                //var timeTrace = new TimeTrace()
                //{
                //    DateTime = date,
                //    DayName = dayName,
                //};
                var plan = dailyDietPlan[i];
                var aDay = ADayBuilder.Create(date, _cultureInfo);
                plan.Day = aDay;
                //plan.Week = setWeekName(i);
            }
        }

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
