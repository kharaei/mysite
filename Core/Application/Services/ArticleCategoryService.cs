
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

    public ArticleCategory Create(ArticleCategoryDto entity)
    {    
        var newRecord = new ArticleCategory();
        newRecord.Title = entity.Title;
        if (entity.ParentCategoryId > 0)
            newRecord.ParentCategoryId = entity.ParentCategoryId;        
        _baseRepository.InsertEntity(newRecord);           
        return newRecord;
    } 
    
    // public override ArticleCategoryDto GetById(int id)
    // {
    //     var articleCategory = _articleCategoryRepository.GetEntity(id);        
    //     return new ArticleCategoryDto{
    //         Id  = articleCategory.Id,
    //         Title = articleCategory.Title            
    //     };
    // }

    // public List<ArticleCategoryDto> GetByTitle(string Title)
    // {
    //     var articleCategories = _articleCategoryRepository.GetEntities(Title);        
    //     var results = new List<ArticleCategoryDto>();
    //     foreach (var item in articleCategories)
    //     {
    //         results.Add(new ArticleCategoryDto{
    //         Id  = item.Id,
    //         Title = item.Title            
    //         });
    //     }
    //     return results;
    // }

}