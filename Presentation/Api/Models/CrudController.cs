using Kharaei.Common;
using Kharaei.Domain;
using Kharaei.Application;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api;
 
 public class CrudController<TService, TEntity, TSelectDto, TDto, TKey> : BaseController
        where TService : IBaseService<TEntity, TSelectDto, TDto, TKey>
        where TEntity : BaseEntity<TKey>, new()
        where TDto : class, new() 
        where TSelectDto : class, new() 
 {
    private readonly TService _service;

    public CrudController(TService Service)
    {
        _service = Service;
    }

    [HttpGet]
    public ApiResult<List<TSelectDto>> Get()
    { 
        return _service.Read();
    } 

    [HttpPost]
    public ApiResult Post(TDto entity)
    {
        _service.Create(entity);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public ApiResult Put(int id, TDto entity)
    {
        _service.Update(id, entity);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public  ApiResult Delete(int id)
    {
        _service.Delete(id);
        return Ok();
    }
 }