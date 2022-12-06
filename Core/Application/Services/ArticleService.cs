
namespace Kharaei.Application;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public List<ArticleDto> Entities()
    {
        var articles = _articleRepository.GetEntities();
        return articles.Select(article => new ArticleDto
        {
            Id = article.Id, 
            Title = article.Title,  
            PublishDateTime = article.PublishDateTime
        }).OrderByDescending(x => x.Id).ToList();
    }

    public ArticleDto Entity(int id)
    {
        var article = _articleRepository.GetEntity(id);        
        return new ArticleDto{
            Id  = article.Id,
            Title = article.Title,
            PublishDateTime = article.PublishDateTime
        };
    }
}