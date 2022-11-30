using AutoMapper.QueryableExtensions;  
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using Kharaei.Common;
using Kharaei.Application;
using AutoMapper;
using Kharaei.Domain;

namespace Kharaei.Api;

public class CrudController<TDto, TSelectDto, TEntity, TKey> : BaseController
        where TDto : BaseDto<TDto, TEntity, TKey>, new()
        where TSelectDto : BaseDto<TSelectDto, TEntity, TKey>, new()
        where TEntity : BaseEntity<TKey>, new()
{
    private readonly IRepository<TEntity> _repository;  
    
    private Mapper _mapper;

    public CrudController(IRepository<TEntity> repository)
    {
        _repository = repository;  
    }

    [HttpGet]
    public virtual async Task<ActionResult<List<TSelectDto>>> Get(CancellationToken cancellationToken)
    { 
        
        var list = await _repository.TableNoTracking.ProjectTo<TSelectDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public virtual async Task<ApiResult<TSelectDto>> Get(int id, CancellationToken cancellationToken)
    {
        var dto = await _repository.TableNoTracking.ProjectTo<TSelectDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(p => p.Id.Equals(id), cancellationToken);

        if (dto == null)
            return NotFound();

        return dto;
    }

    [HttpPost]
    public virtual async Task<ApiResult<TSelectDto>> Create(TDto dto, CancellationToken cancellationToken)
    {
        var model = dto.ToEntity();

        await _repository.AddAsync(model, cancellationToken);

        var resultDto = await _repository.TableNoTracking.ProjectTo<TSelectDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(p => p.Id.Equals(model.Id), cancellationToken);

        return resultDto;
    }

    [HttpPut]
    public virtual async Task<ApiResult<TSelectDto>> Update(TKey id, TDto dto, CancellationToken cancellationToken)
    {
        var model = await _repository.GetByIdAsync(cancellationToken, id);

        model = dto.ToEntity(model);

        await _repository.UpdateAsync(model, cancellationToken);

        var resultDto = await _repository.TableNoTracking.ProjectTo<TSelectDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(p => p.Id.Equals(model.Id), cancellationToken);

        return resultDto;
    }

    [HttpDelete("{id:int}")]
    public virtual async Task<ApiResult> Delete(TKey id, CancellationToken cancellationToken)
    {
        var model = await _repository.GetByIdAsync(cancellationToken, id);

        await _repository.DeleteAsync(model, cancellationToken);

        return Ok();
    }
}

public class CrudController<TDto, TSelectDto, TEntity> : CrudController<TDto, TSelectDto, TEntity, int>
    where TDto : BaseDto<TDto, TEntity, int>, new()
    where TSelectDto : BaseDto<TSelectDto, TEntity, int>, new()
    where TEntity : BaseEntity<int>, new()
{
    public CrudController(IRepository<TEntity> repository)
        : base(repository)
    {
    }
}

public class CrudController<TDto, TEntity> : CrudController<TDto, TDto, TEntity, int>
    where TDto : BaseDto<TDto, TEntity, int>, new()
    where TEntity : BaseEntity<int>, new()
{
    public CrudController(IRepository<TEntity> repository)
        : base(repository)
    {
    }
}