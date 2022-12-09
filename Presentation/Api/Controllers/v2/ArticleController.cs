using Kharaei.Common;
using Microsoft.AspNetCore.Mvc;
using Kharaei.Application;
using Kharaei.Domain;

namespace Kharaei.Api.Controllers.v2;
  
[ApiVersion("2")]
public class ArticleController : CrudController<IArticleService, Article, ArticleSelectDto, ArticleDto, int>
{
     private readonly IArticleService _articleService; 

    public ArticleController(IArticleService articleService): base(articleService)
    {
        _articleService = articleService;
    } 

}