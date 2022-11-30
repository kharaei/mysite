using System.ComponentModel.DataAnnotations;
using Kharaei.Domain;
using Kharaei.Infra;
using AutoMapper;

namespace Kharaei.Api;

public abstract class BaseDto<TDto, TEntity, TKey> : IHaveCustomMapping
        where TDto : class, new()
        where TEntity : BaseEntity<TKey>, new()
{
    [Display(Name = "شناسه")]
    public TKey Id { get; set; }
    
    private Mapper _mapper;

    public TEntity ToEntity()
    {
        return _mapper.Map<TEntity>(CastToDerivedClass(this));
    }

    public TEntity ToEntity(TEntity entity)
    {
        return _mapper.Map(CastToDerivedClass(this), entity);
    }

    // public static TDto FromEntity(TEntity model)
    // {
    //     return _mapper.Map<TDto>(model);
    // }

    protected TDto CastToDerivedClass(BaseDto<TDto, TEntity, TKey> baseInstance)
    {
        return _mapper.Map<TDto>(baseInstance);
    }

    public void CreateMappings(Profile profile)
    {
        var mappingExpression = profile.CreateMap<TDto, TEntity>();

        var dtoType = typeof(TDto);
        var entityType = typeof(TEntity);

        //Ignore any property of source (like Post.Author) that dose not contains in destination 
        foreach (var property in entityType.GetProperties())
        {
            if (dtoType.GetProperty(property.Name) == null)
                mappingExpression.ForMember(property.Name, opt => opt.Ignore());
        }

        CustomMappings(mappingExpression.ReverseMap());
    }

    public virtual void CustomMappings(IMappingExpression<TEntity, TDto> mapping)
    {
    }
} 

public abstract class BaseDto<TDto, TEntity> : BaseDto<TDto, TEntity, int>
        where TDto : class, new()
        where TEntity : BaseEntity<int>, new()
{
     
}