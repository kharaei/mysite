using Kharaei.Common; 
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api;
 
[ApiController] 
[ApiResultFilter] 
[Route("v{version:apiVersion}/[controller]")] 
public class BaseController : ControllerBase
{
    
}