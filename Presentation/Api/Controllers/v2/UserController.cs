using Kharaei.Application;
using Kharaei.Common;
using Kharaei.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kharaei.Api.Controllers.v2;

[ApiVersion("2")] 
[Authorize] 
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
        return _userService.Read();
    } 

    [HttpGet("{userId:int}")]
    public ApiResult<User> Get(int userId)
    {
        return _userService.Read(userId);
    } 

    [HttpGet("{username}")]
    public ApiResult<User> Get(string username)
    {
        return _userService.Read(username);
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

    [HttpPut("{id:int}")]
    public ApiResult Put(int id, UserDto entity)
    {
        _userService.Update(id, entity);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public  ApiResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok();
    }

    [HttpPost("Login")] 
    [AllowAnonymous]
    public ApiResult Login(string mobile)
    {        
        _userService.Login(mobile);
        return new ApiResult(true, ApiResultStatusCode.Success, "کد ورود به شماره موبایل شما ارسال شد.");
    }

    [AllowAnonymous]
    [HttpPost("Token")] 
    public async Task<ApiResult<string>> Token(string username, string password)
    {        
        return await _userService.Token(username, password);
    }
}