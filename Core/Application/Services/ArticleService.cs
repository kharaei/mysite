
using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public List<ArticleDto> GetAll()
    {
        var articles = _articleRepository.GetEntities();
        return articles.Select(article => new ArticleDto
        {
            Id = article.Id, 
            Title = article.Title,  
            PublishDateTime = article.PublishDateTime
        }).OrderByDescending(x => x.Id).ToList();
    }

    public ArticleDto GetById(int id)
    {
        var article = _articleRepository.GetEntity(id);        
        return new ArticleDto{
            Id  = article.Id,
            Title = article.Title,
            PublishDateTime = article.PublishDateTime
        };
    }

    public List<ArticleDto> GetByTitle(string Title)
    {
        var articles = _articleRepository.GetEntities(Title);        
        List<ArticleDto> results = new List<ArticleDto>();
        foreach (var item in articles)
        {
            results.Add(new ArticleDto{
                Id = item.Id,
                Title = item.Title,
                Text = item.Text,
                PublishDateTime = item.PublishDateTime,            
            });
        }
        return results;
    }

    public void Add(ArticleDto entity)
    {
        Article newRecord = new Article{
            Title = entity.Title,
            CategoryId = 1,
            AuthorId = 1,
            Text=entity.Text
        };
        _articleRepository.InsertEntity(newRecord);
        return;
    } 
}