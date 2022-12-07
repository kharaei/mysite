using Kharaei.Common;
using Microsoft.AspNetCore.Mvc;
using Kharaei.Application;

namespace Kharaei.Api.Controllers.v2;
  
[ApiVersion("2")]
public class ArticleController: v1.ArticleController
{
    
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService): base(articleService)
    {
        _articleService = articleService;
    }

    [HttpGet] 
    public override ApiResult<List<ArticleDto>> Get()
    {  
        return base.Get();
    }

    // [HttpGet("{id:int}")]
    // public override ApiResult<ArticleDto> Get(int id)
    // {  
    //     return base.Get(id);
    // }
}