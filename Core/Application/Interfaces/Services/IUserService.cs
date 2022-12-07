using Kharaei.Domain;

namespace  Kharaei.Application;

public interface IUserService 
{  
    List<UserDto> GetAll();
    UserDto GetById(int id);
    Task<string> GenerateToken(string username, string password);
}