using Kharaei.Application;
using Kharaei.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2.0")]  
[Route("api/v2/[controller]")]
[ApiExplorerSettings(GroupName = "v2")] 
public class ArticleController : v1.ArticleController
{ 
    
}