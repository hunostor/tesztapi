using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Extensions
{
    public static class MealExtension
    {
        public static PreparedMeal ToPrepared(this SelectedMeal selectedMeal, SelectedMeal root, int progress)
        {
            var preparedMeal = new PreparedMeal();
            preparedMeal.Root = root;
            preparedMeal.Progress = progress;
            preparedMeal.Trace = selectedMeal.Trace;
            preparedMeal.Calorie = selectedMeal.Calorie;
            preparedMeal.MealId = selectedMeal.MealId;
            preparedMeal.Name = selectedMeal.Name;
            preparedMeal.Portion = selectedMeal.Portion;
            preparedMeal.Protein = selectedMeal.Protein;
            preparedMeal.Carboydrate = selectedMeal.Carboydrate;
            preparedMeal.Fat = selectedMeal.Fat;
            preparedMeal.PreparationSteps = selectedMeal.PreparationSteps;
            preparedMeal.PreparationTime = selectedMeal.PreparationTime;
            preparedMeal.Rating = selectedMeal.Rating;
            preparedMeal.MealTimeOfDay = selectedMeal.MealTimeOfDay;
            preparedMeal.MealTags = selectedMeal.MealTags;
            preparedMeal.Ingredients = selectedMeal.Ingredients;

            return preparedMeal;
        }
    }
}
