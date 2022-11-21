using Microsoft.AspNetCore.Identity;

namespace Kharaei.Domain;

public class Role : IdentityRole<int>, IEntity
{   
    public string? Description { get; set; }
}
