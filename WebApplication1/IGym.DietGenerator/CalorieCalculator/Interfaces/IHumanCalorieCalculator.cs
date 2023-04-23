using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.CalorieCalculator.Interfaces
{
    public interface IHumanCalorieCalculator
    {
        Calorie DaliyCalorieCalculator(Human human);
    }
}
