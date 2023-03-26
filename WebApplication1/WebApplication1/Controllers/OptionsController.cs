using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsController : ControllerBase
    {
        [HttpGet]
        [Route("Genders")]
        public IEnumerable<string> GetGenders()
        {
            var responseList = new List<string>()
            {
                "man",
                "woman"
            };

            return responseList;

        }

        [HttpGet]
        [Route("Goals")]
        public IEnumerable<string> GetGoals()
        {
            var responseList = new List<string>()
            {
                "weightGain",
                "weightLoss"
            };

            return responseList;
        }

        [HttpGet]
        [Route("ExclusionConditions")]
        public IEnumerable<string> GetExclusionConditions()
        {
            var responseList = new List<string>()
            {
                "glutént tartalmaz",
                "tejet tartalmaz",
                "mogyoró tartalmú",
                "húst tartalmaz",
                "állati eredetüt tartalmaz",
                "diót tartalmaz",
                "epret tartalmaz",
                "szója tartalmaz",
                "mustár tartalmaz",
                "zeller tartalmaz",
                "szezámmag tartalmaz",
            };

            return responseList;
        }
    }
}
