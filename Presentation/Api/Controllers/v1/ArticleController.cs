using Kharaei.Common;
using Microsoft.AspNetCore.Mvc;
using Kharaei.Application;

namespace Kharaei.Api.Controllers.v1;
  
[ApiVersion("1")]
public class ArticleController: BaseController
{
    
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet] 
    public virtual ApiResult<List<ArticleDto>> Get()
    {  
        return _articleService.GetList();
    }
}