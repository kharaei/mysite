using Kharaei.Domain;

namespace Kharaei.Application;

public class UserDto : IDto
{
    public string Username { get; set; }  
    public string Gender { get; set; } 
    public string Mobile { get; set; } 
}
 