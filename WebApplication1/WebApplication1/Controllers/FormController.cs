using IGym.DietGenerator;
using IGym.DietGenerator.Enums;
using IGym.DietGenerator.Models;
using IGym.DietGenerator.Req;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
                var dummyMealCount = 250;
                var dietCalculator = dietCalculatorBuilder.Build(dietCalculatorConfig, dummyMealCount);

                var request = new Request()
                {
                    Human = new Human()
                    {
                        Gender = (Genders)Enum.Parse(typeof(Genders), input.Gender),
                        Age = input.Age,
                        Heigth = input.Heigth,
                        Weight = input.Weight
                    },
                    WeeklyWorkout = new IGym.DietGenerator.Req.WeeklyWorkout()
                    {
                        Hard = input.WeeklyWorkout.Hard,
                        Light = input.WeeklyWorkout.Light,
                    },
                    Gooal = (Goals)Enum.Parse(typeof(Goals), input.Goal)
                };

                var generatedDietPlan = dietCalculator.Calculate(request);
                return generatedDietPlan;
            }

            return new GeneratedDietPlan();

        }      
    }
}
