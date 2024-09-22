using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IGym.DietGenerator.Models
{
    public class DietIngredientList
    {
        public IGrouping<int, WeekIngredientList> IngredientList { get; set; }
    }
}
