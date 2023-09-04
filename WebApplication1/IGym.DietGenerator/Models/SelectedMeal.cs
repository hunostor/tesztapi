using IGym.DietGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class SelectedMeal
    {
        public IList<TimeTrace> Trace { get; set; } = new List<TimeTrace>();

        public int Calorie { get; set; }

        public string MealId { get; set; }

        public string Name { get; set; }

        public int Portion { get; set; }

        public int Protein { get; set; } = 0;

        public int Carboydrate { get; set; } = 0;

        public int Fat { get; set; } = 0;

        public IEnumerable<PreparationStep> PreparationSteps { get; set; }

        public int PreparationTime { get; set; }

        public int Rating { get; set; }

        public IEnumerable<MealTimeOfDay> MealTimeOfDay { get; set; } = new List<MealTimeOfDay>();

        public IEnumerable<ExclusionCondition> MealTags { get; set; } = new List<ExclusionCondition>();

        public IEnumerable<MealIngredient> Ingredients { get; set; }

        public string ImageUrl { get; set; }
    }
}
