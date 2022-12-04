using Kharaei.Domain; 
using Kharaei.Application;

namespace Kharaei.Infra.Data;

public class UserRepository:  IUserRepository
{
    private readonly KharaeiDbContext _context;

    public UserRepository(KharaeiDbContext context)
    {
        _context = context;
    }

    List<User> IUserRepository.GetEntities()
    {
        throw new NotImplementedException();
    }

    User IUserRepository.GetEntity(int id)
    {
        throw new NotImplementedException();
    }

}