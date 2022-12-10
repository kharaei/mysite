using Microsoft.AspNetCore.Mvc;
using Kharaei.Application;
using Kharaei.Domain;
using Microsoft.AspNetCore.Authorization;
using Kharaei.Common;

namespace Kharaei.Api.Controllers.v2;
  
[ApiVersion("2")] 
public class ArticleController : CrudController<IArticleService, Article, ArticleSelectDto, ArticleDto, int>
{
     private readonly IArticleService _articleService; 

    public ArticleController(IArticleService articleService): base(articleService)
    {
        _articleService = articleService;
    }  


    [HttpGet]
    [AllowAnonymous]
    public override ApiResult<List<ArticleSelectDto>> Get()
    { 
        return _articleService.Read();
    } 

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public override ApiResult<Article> Get(int id)
    {
        return _articleService.Read(id);        
    }

}