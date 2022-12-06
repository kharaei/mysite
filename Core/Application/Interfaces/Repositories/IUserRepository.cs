using Kharaei.Domain;

namespace Kharaei.Application;

public interface IUserRepository //: IBaseRepository<int, User>
{   
    User GetEntity(int id);
    List<User> GetEntities(); 
}