using Kharaei.Domain;
using Microsoft.AspNetCore.Identity;

namespace  Kharaei.Application;

public interface IUserService 
{  
    IdentityResult Create(UserDto entity);
    List<UserSelectDto> Read();  
    User Read(string username);
    User Read(int userId);
    Task<IdentityResult> Update(int userId, UserDto entity);
    void Delete (int id); 
    void Login(string mobile);
    Task<string> Token(string username, string password);
}