using Kharaei.Common;
using Microsoft.AspNetCore.Mvc;
using Kharaei.Application;
using Kharaei.Domain;

namespace Kharaei.Api.Controllers.v2;
  
[ApiVersion("2")]
public class ArticleController : CrudController<ArticleDto, Article, int>
{
    private readonly IBaseService<ArticleDto, Article, int>  _articleService;

    public ArticleController(IBaseService<ArticleDto, Article, int> articleService): base(articleService)
    {
        _articleService = articleService;
    }
}