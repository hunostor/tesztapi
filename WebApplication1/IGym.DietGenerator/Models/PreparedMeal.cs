using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class PreparedMeal: SelectedMeal
    {
        public SelectedMeal Root { get; set; }

        /// <summary>
        /// portion of progress
        /// </summary>
        public int Progress { get; set; }
    }
}
