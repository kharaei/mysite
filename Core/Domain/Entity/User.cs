using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Kharaei.Domain;

public class User : IdentityUser<int>, IEntity
    {  
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } 
        public GenderType Gender { get; set; } 

        public ICollection<Post> Posts { get; set; }
    }
