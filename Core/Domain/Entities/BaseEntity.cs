using System.ComponentModel.DataAnnotations;

namespace Kharaei.Domain;

public abstract class BaseEntity<TKey> : IEntity
{
    [Key]
    public TKey Id { get; set; }
}

public abstract class BaseEntity : BaseEntity<int>
{
    
}
