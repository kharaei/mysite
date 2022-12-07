using Kharaei.Application;
using Kharaei.Common;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2")]  
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

    [HttpGet("{id:int}")]
    public  ApiResult<ArticleCategoryDto> Get(int id)
    {
        return _articleCategoryService.GetById(id);
    }

    [HttpPost]
    public ApiResult Post(ArticleCategoryDto entity)
    {
        _articleCategoryService.Add(entity);
        return Ok();
    }

}