using Kharaei.Application;
using Kharaei.Common;
using Kharaei.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2")]  
public class UserController : BaseController
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtService _jwtService;
    private readonly IUserService _userService;

    public UserController(IUserService userService, IJwtService jwtService, UserManager<User> userManager)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _userService = userService;
    }

    [HttpGet]
    public ApiResult<List<UserDto>> Get()
    {
        return _userService.Entities();
    }
    
    [HttpGet("{id:int}")]
    public  ApiResult<UserDto> Get(int id)
    {
        return _userService.Entity(id);
    }

    [HttpGet("Token")] 
    public async Task<ApiResult<string>> Token(string username, string password)
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