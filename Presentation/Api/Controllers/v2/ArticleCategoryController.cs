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
        return _articleCategoryService.Read();
    } 

    [HttpGet("{id:int}")]
    public  ApiResult<ArticleCategory> Get(int id)
    {
        return _articleCategoryService.Read(id);
    }

    [HttpPost]
    public ApiResult Post(ArticleCategoryDto entity)
    {
        _articleCategoryService.Create(entity);
        return Ok();
    }
    
    [HttpPut("{id:int}")]
    public ApiResult Put(int id, ArticleCategoryDto entity)
    {
        _articleCategoryService.Update(id, entity);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public  ApiResult Delete(int id)
    {
        _articleCategoryService.Delete(id);
        return Ok();
    }
}