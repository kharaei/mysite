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

    [HttpPut("{id:int}")]
    public ApiResult Put(int id, ArticleDto entity)
    {
        _articleService.Update(id, entity);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public  ApiResult Delete(int id)
    {
        _articleService.Delete(id);
        return Ok();
    }

}