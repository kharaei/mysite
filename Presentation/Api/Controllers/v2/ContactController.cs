using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2")]  
public class ContactController : BaseController
{
    [HttpPost] 
    public IActionResult Post()
    {
        return Ok();
    }
}