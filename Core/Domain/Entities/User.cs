using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Kharaei.Domain;

public class User : IdentityUser<int>, IEntity
{          
    public required string FullName { get; set; } 
    public GenderType Gender { get; set; } 

    public ICollection<Post>? Posts { get; set; }
}


public enum GenderType
{
    [Display(Name = "مرد")]
    Male = 1,

    [Display(Name = "زن")]
    Female = 2
}