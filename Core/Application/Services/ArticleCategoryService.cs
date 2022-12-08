
using Kharaei.Common;
using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleCategoryService : IArticleCategoryService
{    
    private readonly IBaseRepository<ArticleCategory, int> _baseRepository; 

    public ArticleCategoryService(IBaseRepository<ArticleCategory, int> baseRepository)
    { 
        _baseRepository = baseRepository;
    }

    public List<ArticleCategorySelectDto> ReadAll()
    {
        var articlecategories = _baseRepository.GetEntities();
        return articlecategories.Select(articleCategory => new ArticleCategorySelectDto
        {
            Id = articleCategory.Id, 
            Title = articleCategory.Title,  
        }).OrderByDescending(x => x.Id).ToList();
    }
    
    public ArticleCategory Read(int Id)
    {
        return _baseRepository.GetEntity(Id);   
    }

    public ArticleCategory Create(ArticleCategoryDto entity)
    {    
        var newRecord = new ArticleCategory();
        newRecord.Title = entity.Title;
        if (entity.ParentCategoryId > 0)
            newRecord.ParentCategoryId = entity.ParentCategoryId; 

        return _baseRepository.InsertEntity(newRecord);
    } 

    public void Delete(int Id)
    {
        var articleCategory = _baseRepository.GetEntity(Id);
        if (articleCategory == null)
            throw new BadRequestException("شناسه نامعتبر است.");

        _baseRepository.RemoveEntity(articleCategory);        
    }  

}