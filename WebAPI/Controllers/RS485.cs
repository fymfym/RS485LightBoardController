using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RS485 : Controller
    {
        // GET api/RS485
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Post only POST http://.../RS485?Address=?&Intensity=?&Data=?" };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromQuery]int Address, [FromQuery] int Intensity, [FromQuery] int Data)
        {

        }
    }
}
