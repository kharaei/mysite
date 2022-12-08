using Kharaei.Domain;
using Microsoft.AspNetCore.Identity;

namespace  Kharaei.Application;

public interface IUserService 
{  
    List<UserSelectDto> ReadAll(); 
    IdentityResult Create(UserDto entity);
    Task<string> Login(string username, string password);
}