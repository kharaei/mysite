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
    public ApiResult Login(string mobile)
    {        
        _userService.Login(mobile);
        return new ApiResult(true, ApiResultStatusCode.Success, "کد ورود به شماره موبایل شما ارسال شد.");
    }

    [HttpPost("Token")] 
    public async Task<ApiResult<string>> Token(string username, string password)
    {        
        return await _userService.Token(username, password);
    }
}