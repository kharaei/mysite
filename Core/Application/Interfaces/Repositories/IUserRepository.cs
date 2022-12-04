using Kharaei.Domain;

namespace Kharaei.Application;

public interface IUserRepository 
{
    User GetEntity(int id);
    List<User> GetEntities(); 
}