using Kharaei.Domain;

namespace  Kharaei.Application;

public interface IUserService 
{  
    List<UserDto> ReadAll(); 
    Task<string> GenerateToken(string username, string password);
}