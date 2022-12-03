using Microsoft.AspNetCore.Mvc;
using Kharaei.Application;

namespace Kharaei.Api.Controllers.v1;
  
[ApiVersion("1")] 
public class LayoutController : BaseController
{ 
    [HttpGet] 
    public virtual IActionResult Get()
    {  
        return Ok(new LayoutViewModel{
            SiteTitle = "یادداشت‌های رضا خارائی",
            Picture = "https://kharaei.platolms.ir/schools/kharaei/avatars/rezakharaei.jpg",
            Bio = "<p>خوندن این یادداشت‌ها (بعد از گذشتِ چند وقت) بهم کمک می‌کنه تا مسیری که طی کردم رو ببینم و تصمیم‌های بهتری توی آینده بگیرم.</p>",
            Birthday = "1370/02/17",
            PostCount = 1,
            SubscriptionCount = 5,
            Instagram = "https://www.instagram.com/reza.kharaei",
            Linkedin = "https://www.linkedin.com/in/kharaei",
            Twitter = "https://twitter.com/rezakharaei"
        });
    }
}