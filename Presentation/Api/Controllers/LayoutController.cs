
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Kharaei.Api.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class LayoutController : BaseController
{

    [HttpPost("[action]")]
    public IActionResult Get()
    { 
        var model = new LayoutModel{
            Bio = "test...",
            Birthday = "1370/02/17",
            PostCount = 1,
            SiteTitle = "Reza Blog",
            SubscriptionCount = 5,
            Instagram = "#",
            Linkedin = "#",
            Picture = "https://kharaei.platolms.ir/schools/kharaei/avatars/rezakharaei.jpg",
            Twitter = "#"
        };
        return Ok(model);
    }
}