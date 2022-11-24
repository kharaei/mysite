using Microsoft.AspNetCore.Mvc;
using Kharaei.Infra;
using Kharaei.Domain; 
 
namespace Kharaei.Api.Controllers.v1;
  
[ApiVersion("1.0")] 
[Route("v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
public class PostController : CrudController<PostDto, PostSelectDto, Post, int>
{ 
    public PostController(IRepository<Post> repository)    
            : base(repository)
        {
        }
}