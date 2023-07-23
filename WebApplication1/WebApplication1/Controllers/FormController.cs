using IGym.DietGenerator;
using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Repositories;
using IGym.DietGenerator.Req;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {        
        [HttpPost]
        [Route("Input")]
        public GeneratedDietPlan Input([FromBody] FormInput input)
        {
            if (ModelState.IsValid)
            {
                var dietCalculatorConfig = new Config();
                var dietCalculatorBuilder = new DietCalculatorBuilder();
                var conditionsRepo = new DummyExclusionConditionRepository();
                var genderRepo = new GenderRepository();
                var genders = genderRepo.GetAll();
                var goalsRepo = new GoalsRepository();
                var goals = goalsRepo.GetAll();
                var conditions = conditionsRepo.GetAll();
                var dummyMealCount = 250;
                var dietCalculator = dietCalculatorBuilder.Build(dietCalculatorConfig, dummyMealCount);

                var request = new Request()
                {
                    Human = new Human()
                    {
                        Gender = (Genders)Enum.Parse(typeof(Genders), genders.Single(ge => ge.Id == input.Gender).Name),
                        Age = input.Age,
                        Heigth = input.Heigth,
                        Weight = input.Weight
                    },
                    WeeklyWorkout = new IGym.DietGenerator.Req.WeeklyWorkout()
                    {
                        Hard = input.WeeklyWorkout.Hard,
                        Light = input.WeeklyWorkout.Light,
                    },
                    Goal = (Goals)Enum.Parse(typeof(Goals), goals.Single(goal => goal.Id == input.Goal).Name),
                    StartDay = new DateTime(input.StartDay.Year, input.StartDay.Month, input.StartDay.Day)
                };

                foreach (var item in input.ExclusionConditions)
                {
                    request.ExclusionConditions.Add(conditions.SingleOrDefault(x => x.Id == item));
                }

                var generatedDietPlan = dietCalculator.Calculate(request);
                return generatedDietPlan;
            }

            return new GeneratedDietPlan();

        }      
    }
}
