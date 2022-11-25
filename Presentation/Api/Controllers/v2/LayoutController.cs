using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2.0")]  
[Route("api/v2/[controller]")]
[ApiExplorerSettings(GroupName = "v2")] 
public class LayoutController : v1.LayoutController
{
    [HttpGet] 
    public override IActionResult Get()
    {
        return Ok();
    }
}