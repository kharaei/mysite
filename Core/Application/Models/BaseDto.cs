using System.ComponentModel.DataAnnotations;
using Kharaei.Domain;

namespace Kharaei.Application;

public class BaseDto<TKey> : IDto
{
    [Display(Name = "شناسه")]
    public TKey Id { get; set; }
     
} 