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
    public ApiResult<List<UserSelectDto>> Get()
    {
        return _userService.ReadAll();
    } 

    [HttpPost]
    public ApiResult Post(UserDto entity)
    {
        var result = _userService.Create(entity);
        string desc = "";
        if (result.Errors.Any())
            desc = result.Errors.FirstOrDefault().Description;
            
        return new ApiResult(result.Succeeded, ApiResultStatusCode.Success, desc);
    } 

    [HttpPost("Login")] 
    public async Task<ApiResult<string>> Login(string username, string password)
    {        
        return await _userService.Login(username, password);
    }
}