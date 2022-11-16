using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Kharaei.Domain;

namespace Kharaei.Infra.Data;

public class ApplicationDbContext: IdentityDbContext<User, Role, int>
{
     public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
} 