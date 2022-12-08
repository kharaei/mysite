using Kharaei.Common;
using Kharaei.Domain;
using Kharaei.Application;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api;
  
[ApiController] 
[ApiResultFilter] 
public class CrudController<TDto, TEntity, TKey> : BaseController
        where TDto: IDto, new() 
        where TEntity: IEntity, new()
        
{
    // private readonly IBaseService<TDto, TEntity, TKey> _service;
    
    // public CrudController(IBaseService<TDto, TEntity, TKey> service)
    // {
    //     _service = service;
    // }
 
    // [HttpGet]
    // public ApiResult<List<TDto>> Get()
    // {
    //     return _service.GetAll();
    // }

    // // [HttpGet("{id}")]
    // // public ApiResult<TDto> Get(TKey id)
    // // {
    // //     return _service.GetById(id);
    // // }

    // [HttpPost]
    // public ApiResult Post(TDto entity)
    // {
    //     _service.Add(entity);
    //     return Ok();
    // }
}