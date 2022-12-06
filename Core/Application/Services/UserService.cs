
using Kharaei.Common;
using Kharaei.Domain;
using Microsoft.AspNetCore.Identity;

namespace Kharaei.Application;

public class UserService : IUserService
{  
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<UserDto> Entities()
    {
        var users = _userRepository.GetEntities();
        return users.Select(user => new UserDto
        {
            Id = user.Id, 
            Username = user.UserName,  
            Gender = user.Gender.ToString()
        }).OrderByDescending(x => x.Id).ToList();
    }

    public UserDto Entity(int id)
    {
        var user = _userRepository.GetEntity(id);        
        return new UserDto{
            Id  = user.Id,
            Username = user.UserName,
            Gender = user.Gender.ToString()
        };
    } 
 
}