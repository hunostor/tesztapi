using IGym.DietGenerator.Repositories;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsController : ControllerBase
    {
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
        [Route("ExclusionConditions")]
        public IEnumerable<Select> GetExclusionConditions()
        {
            var repo =  new ExclusionRepository();
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
    }
}
