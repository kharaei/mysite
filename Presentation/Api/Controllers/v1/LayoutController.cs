using Microsoft.AspNetCore.Mvc;
using Kharaei.Application;

namespace Kharaei.Api.Controllers.v1;
  
[ApiVersion("1")] 
public class LayoutController : BaseController
{ 
    [HttpGet] 
    public virtual IActionResult Get()
    { 
        var model = new LayoutViewModel{
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