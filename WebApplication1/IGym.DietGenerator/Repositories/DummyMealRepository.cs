using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Factories;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Models.Interfaces;
using IGym.DietGenerator.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Repositories
{
    public class DummyMealRepository : Interfaces.IRepository<Meal>
    {
        private IEnumerable<Meal> _meals => new List<Meal>()
        {
            new Meal()
            {
                Name = "Mézes-joghurtos banánpalacsinta, kávéval* (kb. 3 db kistenyérnyi nagyságú)",
                Calorie = new Calorie(638),
                MealTimeOfDay = new List<MealTimeOfDay>()
                {
                    MealTimeOfDay.Lunch,
                    MealTimeOfDay.Breakfast
                },
                MealTags = new List<IMealTag>()
                {
                    new ExclusionCondition()
                    {
                        Name = "laktóz intolerancia",
                        Description = "lorem ipsum",
                        Type = Enums.ExclusionConditionTypes.allergies
                    }
                }
            },
            new Meal()
            {
                Name = "Padlizsánkrémes abonett koktélparadicsommal",
                Calorie = new Calorie(638),
                MealTimeOfDay = new List<MealTimeOfDay>()
                {
                    MealTimeOfDay.Lunch,
                    MealTimeOfDay.Breakfast
                },
                MealTags = new List<IMealTag>()
                {
                    new ExclusionCondition()
                    {
                        Name = "laktóz intolerancia",
                        Description = "lorem ipsum",
                        Type = Enums.ExclusionConditionTypes.allergies
                    }
                }
            },
            new Meal()
            {
                Name = "Házi sajtos burrito",
                Calorie = new Calorie(638),
                MealTimeOfDay = new List<MealTimeOfDay>()
                {
                    MealTimeOfDay.Lunch,
                    MealTimeOfDay.Breakfast
                },
                MealTags = new List<IMealTag>()
                {
                    new ExclusionCondition()
                    {
                        Name = "laktóz intolerancia",
                        Description = "lorem ipsum",
                        Type = Enums.ExclusionConditionTypes.allergies
                    }
                }
            },
        };

        private int _generatedMealCount = 0;

        public DummyMealRepository(int generatedMealCount)
        {
            _generatedMealCount = generatedMealCount;
        }

        public IEnumerable<Meal> GetAll()
        {
            var factory = new DummyMealFactory();

            return factory.GetMeals(_generatedMealCount);
        }
    }
}
