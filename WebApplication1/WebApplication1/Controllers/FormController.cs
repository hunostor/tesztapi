using Microsoft.AspNetCore.Mvc;
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
        public FormInput Input([FromBody] FormInput input)
        {
            if (ModelState.IsValid)
            {
                return input;
            }

            return input;

        }      
    }
}
