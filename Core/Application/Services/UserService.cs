using Kharaei.Common;
using Kharaei.Domain;
using Microsoft.AspNetCore.Identity;

namespace Kharaei.Application;

public class UserService : IUserService
{   
    private readonly UserManager<User> _userManager;
    private readonly IJwtService _jwtService;

    public UserService(IJwtService jwtService, UserManager<User> userManager)
    { 
        _userManager = userManager;
        _jwtService = jwtService;
    }

    public List<UserSelectDto> ReadAll()
    {   
        return _userManager.Users.Select(user => new UserSelectDto
        { 
            Id = user.Id,
            UserName = user.PhoneNumber,  
            Gender = user.Gender.ToString(),
            Fullname = user.FullName,            
        }).ToList();
    } 
 
    public void Login(string mobile)
    {
        var user = _userManager.FindByNameAsync(mobile).Result;
        if (user == null)
            throw new BadRequestException("کاربری با این شماره موبایل وجود ندارد.");
        
        _userManager.RemovePasswordAsync(user);
        _userManager.AddPasswordAsync(user, "123456");
    }

    public async Task<string> Token(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
            throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
        if (!isPasswordValid)
            throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");
 
        var jwt = await _jwtService.Generate(user);
        return jwt;
    }

    public IdentityResult Create(UserDto entity)
    {
        return _userManager.CreateAsync(new User{
            Gender = entity.Gender,
            UserName = entity.PhoneNumber,
            PhoneNumber = entity.PhoneNumber,
            Email = entity.Email,
            FullName = entity.Fullname            
        }).Result;
    }
}