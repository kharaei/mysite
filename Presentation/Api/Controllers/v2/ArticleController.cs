using Kharaei.Common;
using Microsoft.AspNetCore.Mvc;
using Kharaei.Application;
using Kharaei.Domain;

namespace Kharaei.Api.Controllers.v2;
  
[ApiVersion("2")]
public class ArticleController : BaseController
{
     private readonly IArticleService _articleService; 

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet]
    public ApiResult<List<ArticleSelectDto>> Get()
    {
        return _articleService.Read();
    } 

    [HttpPost]
    public ApiResult Post(ArticleDto entity)
    {
        _articleService.Create(entity);
        return Ok();
    }

}