using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace IGym.DietGenerator.Builders
{
    public static class ADayBuilder
    {
        public static ADay Create(DateTime date, CultureInfo cultureInfo)
        {
            return new ADay(date, cultureInfo);
        }
    }
}
