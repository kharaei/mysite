using Microsoft.AspNetCore.Mvc;
using Kharaei.Application;
using Kharaei.Domain; 
 
namespace Kharaei.Api.Controllers.v1;
  
[ApiVersion("1.0")]  
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
public class ArticleController : CrudController
{ 
    
}