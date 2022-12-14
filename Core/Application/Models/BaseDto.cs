using System.ComponentModel.DataAnnotations; 
using Kharaei.Domain;
using AutoMapper;

namespace Kharaei.Application;

public abstract class BaseDto<TDto, TEntity, TKey>
    where TDto : class, new()
    where TEntity : BaseEntity<TKey>, new()
{
    [Display(Name = "شناسه")]
    public TKey Id { get; set; }

    // public TEntity ToEntity()
    // {
    //     return Mapper.Map<TEntity>(CastToDerivedClass(this));
    // }

    // public TEntity ToEntity(TEntity entity)
    // {
    //     return Mapper.Map(CastToDerivedClass(this), entity);
    // }

    // public static TDto FromEntity(TEntity model)
    // {
    //     return Mapper.Map<TDto>(model);
    // }

    // protected TDto CastToDerivedClass(BaseDto<TDto, TEntity, TKey> baseInstance)
    // {
    //     return Mapper.Map<TDto>(baseInstance);
    // }
 
}

public abstract class BaseDto<TDto, TEntity> : BaseDto<TDto, TEntity, int>
    where TDto : class, new()
    where TEntity : BaseEntity<int>, new()
{

}