
using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleCategoryService : IArticleCategoryService
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoryService(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    public List<ArticleCategoryDto> Entities()
    {
        var articlecategories = _articleCategoryRepository.GetEntities();
        return articlecategories.Select(articleCategory => new ArticleCategoryDto
        {
            Id = articleCategory.Id, 
            Title = articleCategory.Title,  
        }).OrderByDescending(x => x.Id).ToList();
    }
    
    public ArticleCategoryDto Entity(int id)
    {
        var articleCategory = _articleCategoryRepository.GetEntity(id);        
        return new ArticleCategoryDto{
            Id  = articleCategory.Id,
            Title = articleCategory.Title            
        };
    }

    public void Add(ArticleCategoryDto entity)
    {
        ArticleCategory newRecord = new ArticleCategory{
            Title = entity.Title,
            ParentCategoryId = 0
        };
        _articleCategoryRepository.InsertEntity(newRecord);
        return;
    } 
}