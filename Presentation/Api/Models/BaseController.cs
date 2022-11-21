using Kharaei.Infra;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api;

[ApiController] 
[ApiResultFilter]
//[Route("api/v{version:apiVersion}/[controller]")]// api/v1/[controller]
public class BaseController : ControllerBase
{
    //public UserRepository UserRepository { get; set; } => property injection
    public bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
}