using Kharaei.Common;
using Kharaei.Domain;
using Kharaei.Application;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api;
  
[ApiController] 
[ApiResultFilter] 
public class CrudController<TDto, TEntity, TKey> : BaseController
        where TDto : BaseDto<TDto, TEntity, TKey>, new() 
        where TEntity : BaseEntity<TKey>, new()
{ 
    // private readonly IBaseRepository<int, TEntity> _repository;
    
    // public CrudController(IBaseRepository<int, TEntity> repository)
    // {
    //     _repository = repository;
    // }
}