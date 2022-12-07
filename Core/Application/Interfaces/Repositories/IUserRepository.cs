using Kharaei.Domain;

namespace Kharaei.Application;

public interface IUserRepository //: IBaseRepository<int, User>
{   
    List<User> GetEntities(); 
    User GetEntity(int id);
}