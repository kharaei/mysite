using Kharaei.Application;
using Kharaei.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2")]  
public class ArticleCategoryController : CrudController<ArticleCategoryDto, ArticleCategory, int>
{
    private readonly IBaseService<ArticleCategoryDto, ArticleCategory, int>  _articleCategoryService;

    public ArticleCategoryController(IBaseService<ArticleCategoryDto, ArticleCategory, int> articleCategoryService): base(articleCategoryService)
    {
        _articleCategoryService = articleCategoryService;
    }
 
}