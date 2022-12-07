using System.ComponentModel.DataAnnotations;

namespace Kharaei.Domain;

public class BaseEntity<TKey>: IEntity
{
    [Key]
    public TKey Id { get; set; }
} 
