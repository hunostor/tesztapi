using IGym.DietGenerator.Repositories;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsController : ControllerBase
    {
        [HttpGet]
        [Route("Trainers")]
        public IEnumerable<Select> GetTrainers()
        {
            var repo = new TrainersRepository();
            var list = repo.GetAll();
            var responseList = new List<Select>();
            foreach (var item in list)
            {
                responseList.Add(new Select()
                {
                    Id = item.Id,
                    Label = item.Name
                });
            }

            return responseList;

        }

        [HttpGet]
        [Route("Genders")]
        public IEnumerable<Select> GetGenders()
        {
            var repo = new GenderRepository();
            var list = repo.GetAll();
            var responseList = new List<Select>();
            foreach (var item in list)
            {
                responseList.Add(new Select()
                {
                    Id = item.Id,
                    Label = item.Name
                });
            }

            return responseList;

        }

        [HttpGet]
        [Route("Goals")]
        public IEnumerable<Select> GetGoals()
        {
            var repo = new GoalsRepository();
            var list = repo.GetAll();
            var responseList = new List<Select>();
            foreach (var item in list)
            {
                responseList.Add(new Select()
                {
                    Id = item.Id,
                    Label = item.Name
                });
            }

            return responseList;
        }

        [HttpGet]
        [Route("exclusionintolerance")]
        public IEnumerable<Select> GetExclusionIntolerance()
        {
            var repo = new DummyExclusionConditionRepository();
            var list = repo.GetAll()
                .Where(x => x.Type == IGym.DietGenerator.Enums.ExclusionConditionTypes.intolerance_or_food_allergy);
            var responseList = new List<Select>();
            foreach (var item in list)
            {
                responseList.Add(new Select()
                {
                    Id = item.Id,
                    Label = item.Label
                });
            }

            return responseList;
        }

        [HttpGet]
        [Route("exclusiondontlike/foods")]
        public IEnumerable<Select> GetExclusionMeat()
        {
            var repo = new DummyExclusionConditionRepository();
            var list = repo.GetAll()
                .Where(x => x.Type == IGym.DietGenerator.Enums.ExclusionConditionTypes.meat_and_fish);
            var responseList = new List<Select>();
            foreach (var item in list)
            {
                responseList.Add(new Select()
                {
                    Id = item.Id,
                    Label = item.Label
                });
            }

            return responseList;
        }

        [HttpGet]
        [Route("exclusiondontlike/sides")]
        public IEnumerable<Select> GetExclusionSideDish()
        {
            var repo = new DummyExclusionConditionRepository();
            var list = repo.GetAll()
                .Where(x => x.Type == IGym.DietGenerator.Enums.ExclusionConditionTypes.side_dish);
            var responseList = new List<Select>();
            foreach (var item in list)
            {
                responseList.Add(new Select()
                {
                    Id = item.Id,
                    Label = item.Label
                });
            }

            return responseList;
        }

        [HttpGet]
        [Route("exclusiondontlike/fruits")]
        public IEnumerable<Select> GetExclusionFruits()
        {
            var repo = new DummyExclusionConditionRepository();
            var list = repo.GetAll()
                .Where(x => x.Type == IGym.DietGenerator.Enums.ExclusionConditionTypes.fruit);
            var responseList = new List<Select>();
            foreach (var item in list)
            {
                responseList.Add(new Select()
                {
                    Id = item.Id,
                    Label = item.Label
                });
            }

            return responseList;
        }

        [HttpGet]
        [Route("exclusiondontlike/vegetables")]
        public IEnumerable<Select> GetExclusionVegetables()
        {
            var repo = new DummyExclusionConditionRepository();
            var list = repo.GetAll()
                .Where(x => x.Type == IGym.DietGenerator.Enums.ExclusionConditionTypes.vegetable);
            var responseList = new List<Select>();
            foreach (var item in list)
            {
                responseList.Add(new Select()
                {
                    Id = item.Id,
                    Label = item.Label
                });
            }

            return responseList;
        }

        [HttpGet]
        [Route("exclusiondontlike/ingredients")]
        public IEnumerable<Select> GetExclusionIngredients()
        {
            var repo = new DummyExclusionConditionRepository();
            var list = repo.GetAll()
                .Where(x => x.Type == IGym.DietGenerator.Enums.ExclusionConditionTypes.food_stuff);
            var responseList = new List<Select>();
            foreach (var item in list)
            {
                responseList.Add(new Select()
                {
                    Id = item.Id,
                    Label = item.Label
                });
            }

            return responseList;
        }
    }
}
