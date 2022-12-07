using Kharaei.Common;
using Kharaei.Domain;
using Microsoft.AspNetCore.Identity;

namespace Kharaei.Application;

public class UserService : IUserService
{  
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly IJwtService _jwtService;

    public UserService(IUserRepository userRepository, IJwtService jwtService, UserManager<User> userManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _jwtService = jwtService;
    }

    public List<UserDto> GetAll()
    { 
        var users = _userRepository.GetEntities();
        return users.Select(user => new UserDto
        { 
            Username = user.UserName,  
            Gender = user.Gender.ToString()
        }).ToList();
    }

    public UserDto GetById(int id)
    {
        var user = _userRepository.GetEntity(id);        
        return new UserDto{ 
            Username = user.UserName,
            Gender = user.Gender.ToString()
        };
    } 
 
    public async Task<string> GenerateToken(string username, string password)
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
}