using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleService : IArticleService
{
    private readonly IBaseRepository<Article, int> _baseRepository; 

    public ArticleService(IBaseRepository<Article, int> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public List<ArticleSelectDto> ReadAll()
    {
        var articles = _baseRepository.GetEntities();
        return articles.Select(article => new ArticleSelectDto
        {
            Id = article.Id, 
            Title = article.Title,  
            PublishDateTime = article.PublishDateTime
        }).OrderByDescending(x => x.Id).ToList();
    }

    public Article Create(ArticleDto entity)
    {
        Article newRecord = new Article{
            Title = entity.Title,
            CategoryId = 1,
            AuthorId = 1,
            Text=entity.Text
        };
        _baseRepository.InsertEntity(newRecord);
        return newRecord;
    } 
    
    // public ArticleDto GetById(int id)
    // {
    //     var article = _articleRepository.GetEntity(id);        
    //     return new ArticleDto{
    //         Id  = article.Id,
    //         Title = article.Title,
    //         PublishDateTime = article.PublishDateTime
    //     };
    // }

    // public List<ArticleDto> GetByTitle(string Title)
    // {
    //     var articles = _articleRepository.GetEntities(Title);        
    //     var results = new List<ArticleDto>();
    //     foreach (var item in articles)
    //     {
    //         results.Add(new ArticleDto{
    //             Id = item.Id,
    //             Title = item.Title,
    //             Text = item.Text,
    //             PublishDateTime = item.PublishDateTime,            
    //         });
    //     }
    //     return results;
    // }

}