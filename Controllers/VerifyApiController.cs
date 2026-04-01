using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace KunjLakhaniApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class VerifyApiController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetVerify()
        {
            var builderName = "Kunj Lakhani";
            var runner = Environment.GetEnvironmentVariable("RUN_BY")??"NOT_DEFINED";
            var timestamp = DateTime.UtcNow;
            var machineName = Dns.GetHostName();

            return Ok(new
            {
                builder= builderName,
                runner=runner,
                timestamp=timestamp,
                machineName=machineName
            });
        }
    }  
}