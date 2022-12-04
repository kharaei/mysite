
namespace Kharaei.Application;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _repository;

    public ArticleService(IArticleRepository repository)
    {
        _repository = repository;
    }

    public List<ArticleDto> GetList()
    {
        var articles = _repository.GetEntities();
        return articles.Select(article => new ArticleDto
        {
            Id = article.Id, 
            Title = article.Title,  
            PublishDateTime = article.PublishDateTime
        }).OrderByDescending(x => x.Id).ToList();
    }
}