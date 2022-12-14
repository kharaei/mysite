using Kharaei.Domain;

namespace Kharaei.Application;

public class UserDto
{ 
    public string PhoneNumber { get; set; } 
    public GenderType Gender { get; set; } 
    public string Fullname { get; set; }  
    public string Email { get; set; }  
}
 
public class UserSelectDto 
{ 
    public int Id { get; set; }
    public string UserName { get; set; }    
    public string Gender { get; set; } 
    public string Fullname { get; set; }    
}

public class LoginDto
{
    public string mobile { get; set; }
}

public class TokenDto
{
    public string username { get; set; }
    public string password { get; set; }
}