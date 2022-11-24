using Kharaei.Infra;
using Kharaei.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2.0")]  
[Route("v2/[controller]")]
[ApiExplorerSettings(GroupName = "v2")] 
public class PostsController : v1.PostsController
{
    public PostsController(IRepository<Post> repository)
            : base(repository)
    {
    }
}