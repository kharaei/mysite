
namespace Kharaei.Application;

public class UserService : IUserService
{
    private readonly IArticleRepository _repository;

    public UserService(IArticleRepository repository)
    {
        _repository = repository;
    }

    public bool Login(string username, string password)
    {
        return false;
    }
}