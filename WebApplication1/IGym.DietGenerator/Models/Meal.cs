using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models.Interfaces;
using IGym.DietGenerator.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class Meal: ICloneable<Meal>
    {
        public string MealId { get; set; }

        public string Name { get; set; }

        public int Portion { get; set; }

        public Calorie Calorie { get; set; }

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

        public SelectedMeal ToSelected()
        {
            var selected = new SelectedMeal()
            {
                MealId = this.MealId,
                Name = this.Name,
                Portion = this.Portion,
                Calorie = (int)this.Calorie.Value,
                Protein = this.Protein,
                Carboydrate = this.Carboydrate,
                Fat = this.Fat,
                MealTimeOfDay = this.MealTimeOfDay,
                MealTags = this.MealTags,                
                Ingredients = this.Ingredients,
                ImageUrl = this.ImageUrl,
                PreparationSteps = this.PreparationSteps,
            };

            return selected;
        }

        public Meal Clone()
        {
            return new Meal()
            {
                MealId = this.MealId,
                Name = this.Name,
                Portion = this.Portion,
                Calorie = this.Calorie,
                Protein = this.Protein,
                Carboydrate = this.Carboydrate,
                Fat = this.Fat,
                MealTimeOfDay = this.MealTimeOfDay,
                MealTags = this.MealTags,
                Ingredients = this.Ingredients,
                ImageUrl = this.ImageUrl,
                PreparationSteps = this.PreparationSteps,
            };
        }
    }
}
