using Kharaei.Common;
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
            Text=entity.Text,
            PublishDateTime = entity.PublishDateTime,
            Image = entity.Image
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
  
    public void Update(int Id, ArticleDto dto)
    {
        var model = _baseRepository.GetById(Id);
        model.Title = dto.Title;
        model.Text = dto.Text;
        model.CategoryId = dto.CategoryId;
        model.AuthorId = dto.AuthorId;
        model.Image = dto.Image;
        _baseRepository.Update(model);
    }

    public void Delete(int Id)
    {
        var article = _baseRepository.GetById(Id);
        if (article == null)
            throw new BadRequestException("شناسه نامعتبر است.");

        _baseRepository.Delete(article);        
    } 

}