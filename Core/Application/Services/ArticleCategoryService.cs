
using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleCategoryService : IArticleCategoryService
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoryService(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    public List<ArticleCategoryDto> GetAll()
    {
        var articlecategories = _articleCategoryRepository.GetEntities();
        return articlecategories.Select(articleCategory => new ArticleCategoryDto
        {
            Id = articleCategory.Id, 
            Title = articleCategory.Title,  
        }).OrderByDescending(x => x.Id).ToList();
    }
    
    public ArticleCategoryDto GetById(int id)
    {
        var articleCategory = _articleCategoryRepository.GetEntity(id);        
        return new ArticleCategoryDto{
            Id  = articleCategory.Id,
            Title = articleCategory.Title            
        };
    }

    public List<ArticleCategoryDto> GetByTitle(string Title)
    {
        var articleCategories = _articleCategoryRepository.GetEntities(Title);        
        var results = new List<ArticleCategoryDto>();
        foreach (var item in articleCategories)
        {
            results.Add(new ArticleCategoryDto{
            Id  = item.Id,
            Title = item.Title            
            });
        }
        return results;
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