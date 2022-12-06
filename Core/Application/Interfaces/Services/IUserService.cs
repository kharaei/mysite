using Kharaei.Domain;

namespace  Kharaei.Application;

public interface IUserService 
{  
    List<UserDto> Entities();
    UserDto Entity(int id);
}