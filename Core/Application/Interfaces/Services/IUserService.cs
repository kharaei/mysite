using Kharaei.Domain;
using Microsoft.AspNetCore.Identity;

namespace  Kharaei.Application;

public interface IUserService 
{  
    List<UserSelectDto> ReadAll(); 
    IdentityResult Create(UserDto entity);
    void Login(string mobile);
    Task<string> Token(string username, string password);
}