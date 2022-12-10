using Kharaei.Application; 
using Kharaei.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2")]  
[Authorize]
[Route("api/v{version:apiVersion}/Article/Category")] 
public class ArticleCategoryController : CrudController<IArticleCategoryService, ArticleCategory, ArticleCategorySelectDto, ArticleCategoryDto, int>
{
    private readonly IArticleCategoryService _articleCategoryService;

    public ArticleCategoryController(IArticleCategoryService articleCategoryService): base(articleCategoryService)
    {
        _articleCategoryService = articleCategoryService;
    } 

}