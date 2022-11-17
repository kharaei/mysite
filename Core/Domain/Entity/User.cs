using Microsoft.AspNetCore.Identity;

namespace Kharaei.Domain;

public class User : IdentityUser<int>, IEntity
    {          
        public required string FullName { get; set; } 
        public GenderType Gender { get; set; } 

        public ICollection<Post>? Posts { get; set; }
    }
