using Microsoft.AspNetCore.Mvc;
using Kharaei.Infra.Ioc;
using Microsoft.Extensions.Options;
using Kharaei.Application;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2")]
public class LayoutController: v1.LayoutController
{
    private readonly IOptions<SiteSettings> _siteSetting;

    public LayoutController(IOptions<SiteSettings> SiteSettings) => _siteSetting = SiteSettings;

    [HttpGet]
    public override IActionResult Get()
    {
        var model = new LayoutDto {
            SiteTitle =_siteSetting.Value.LayoutInformationSettings.SiteTitle,
            Picture = _siteSetting.Value.LayoutInformationSettings.Picture,
            Bio = _siteSetting.Value.LayoutInformationSettings.Bio,
            Birthday = _siteSetting.Value.LayoutInformationSettings.Birthday,
            PostCount = _siteSetting.Value.LayoutInformationSettings.PostCount,
            SubscriptionCount = _siteSetting.Value.LayoutInformationSettings.SubscriptionCount,
            Instagram = _siteSetting.Value.LayoutInformationSettings.Instagram,
            Linkedin = _siteSetting.Value.LayoutInformationSettings.Linkedin,
            Twitter = _siteSetting.Value.LayoutInformationSettings.Twitter
        };
        return Ok(model);
    }
} 