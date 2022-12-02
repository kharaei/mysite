using Kharaei.Application;
using Kharaei.Common;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v1;

[ApiVersion("1")]  
public class ArticleCategoryController : BaseController
{
    private readonly IArticleCategoryService  _articleCategoryService;

    public ArticleCategoryController(IArticleCategoryService articleCategoryService)
    {
        _articleCategoryService = articleCategoryService;
    }

    [HttpGet]
    public ApiResult<List<ArticleCategoryDto>> Get()
    {
        return _articleCategoryService.GetAll();
    }

    // [HttpGet("{id:guid}")]
    // public  ApiResult<ArticleCategoryDto> Get(int id)
    // { 
    //     return _articleCategoryService.get();
    // }

}