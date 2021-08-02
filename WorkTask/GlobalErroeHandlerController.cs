using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTask
{

    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class GlobalErroeHandlerController : ControllerBase
    {
        [HttpGet]
        [Route("/errors")]
        public IActionResult HandelError()
        {
            return Problem("SomeThing Went Wrong");
        }
    }
}
