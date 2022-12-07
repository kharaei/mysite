using Kharaei.Application;
using Kharaei.Common; 
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2")]  
public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ApiResult<List<UserDto>> Get()
    {
        return _userService.GetAll();
    }
    
    [HttpGet("{id:int}")]
    public  ApiResult<UserDto> Get(int id)
    {
        return _userService.GetById(id);
    }

    [HttpPost("Login")] 
    public async Task<ApiResult<string>> Login(string username, string password)
    {        
        return await _userService.GenerateToken(username, password);
    }
}