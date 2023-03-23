using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        [HttpGet]
        [Route("GetGenders")]
        public IEnumerable<string> GetGenders()
        {
            var responseList = new List<string>()
            {
                "man",
                "woman"
            };

            return responseList;

        }

        [HttpPost]
        [Route("Input")]
        public FormInput Input([FromBody] FormInput input)
        {

            return input;

        }

        [HttpGet]
        [Route("GetExclusionConditions")]
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
