using Kharaei.Domain;

namespace  Kharaei.Application;

public interface IJwtService
{
    Task<string> Generate(User user);
}