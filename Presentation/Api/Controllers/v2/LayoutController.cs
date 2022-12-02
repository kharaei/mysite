using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2")]   
public class LayoutController: BaseController
{
    [HttpGet] 
    public IActionResult Get()
    {
        return Ok();
    }
}