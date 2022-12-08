using Kharaei.Domain;

namespace Kharaei.Application;

public interface IUserRepository
{   
    List<User> GetEntities();  
}