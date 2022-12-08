using Kharaei.Application;
using Kharaei.Common;
using Kharaei.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2")]  
public class ArticleCategoryController : BaseController
{
    private readonly IArticleCategoryService _articleCategoryService;

    public ArticleCategoryController(IArticleCategoryService articleCategoryService)
    {
        _articleCategoryService = articleCategoryService;
    }
 
    [HttpGet]
    public ApiResult<List<ArticleCategorySelectDto>> Get()
    {
        return _articleCategoryService.ReadAll();
    } 

    [HttpPost]
    public ApiResult Post(ArticleCategoryDto entity)
    {
        _articleCategoryService.Create(entity);
        return Ok();
    }

}