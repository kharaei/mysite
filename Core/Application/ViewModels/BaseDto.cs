using System.ComponentModel.DataAnnotations;
using Kharaei.Domain;

namespace Kharaei.Application;

public abstract class BaseDto<TDto, TEntity, TKey>
        where TDto : class, new()
        where TEntity : BaseEntity<TKey>, new()
{
    [Display(Name = "شناسه")]
    public TKey Id { get; set; }
     
} 