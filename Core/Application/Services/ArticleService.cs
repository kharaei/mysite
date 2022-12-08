using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleService : IArticleService
{
    private readonly IBaseRepository<Article> _baseRepository; 

    public ArticleService(IBaseRepository<Article> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public void Create(ArticleDto entity)
    {
        Article newRecord = new Article{
            Title = entity.Title,
            CategoryId = entity.CategoryId,
            AuthorId = entity.AuthorId,
            Text=entity.Text
        };
        _baseRepository.Add(newRecord);        
    } 

    public List<ArticleSelectDto> Read()
    {
        var articles = _baseRepository.TableNoTracking.ToList();
        return articles.Select(article => new ArticleSelectDto
        {
            Id = article.Id, 
            Title = article.Title,  
            PublishDateTime = article.PublishDateTime
        }).OrderByDescending(x => x.Id).ToList();
    }
    
    public Article Read(int id)
    {     
        return _baseRepository.GetById(id);
    }
  
}