
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LayoutController : ControllerBase
{

    [HttpPost("[action]")]
    public IActionResult Get()
    { 
        return Ok();
    }
}