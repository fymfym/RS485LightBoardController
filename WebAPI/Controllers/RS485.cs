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
            return new string[] { "Post only POST http://.../RS485?Base64EncodedDataPackage=<Base 64 encoded byte array length 2 to 16>" };
        }

        // POST api/RS485
        [HttpPost]
        public IActionResult Post([FromQuery] string Base64EncodedDataPackage)
        {
            if (Base64EncodedDataPackage == null) return BadRequest();
            var dataPackage = System.Convert.FromBase64String(Base64EncodedDataPackage);

            if (dataPackage.Length < 2) return BadRequest();
            if (dataPackage.Length > 16) return BadRequest();
            if (dataPackage[0] > 16) return BadRequest();
            if (dataPackage[0] < 1) return BadRequest();

            for (int i = 1; i < dataPackage.Length; i++)
            {
                if (dataPackage[i] < 10) return BadRequest();
            }

            // Open RS486
            // Send data to RS485
            // Close RS485

            return Ok();
        }
    }
}
