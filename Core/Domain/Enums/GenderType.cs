
using System.ComponentModel.DataAnnotations;

namespace Kharaei.Domain;

public enum GenderType
{
    [Display(Name = "مرد")]
    Male = 1,

    [Display(Name = "زن")]
    Female = 2
}