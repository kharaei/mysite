using Kharaei.Domain; 
using Kharaei.Application;

namespace Kharaei.Infra.Data;

public class UserRepository:  IUserRepository
{
    private readonly KharaeiDbContext _dbcontext;

    public UserRepository(KharaeiDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public List<User> GetEntities()
    {
        return _dbcontext.Set<User>().ToList();
    }

    public User GetEntity(int id)
    {
        return _dbcontext.Find<User>(id);
    }

}