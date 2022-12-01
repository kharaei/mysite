
namespace Kharaei.Application;

public class ArticleCategoryService : IArticleCategoryService
{
    private readonly IArticleCategoryRepository _repository;

    public ArticleCategoryService(IArticleCategoryRepository repository)
    {
        _repository = repository;
    }

    public List<ArticleCategoryDto> GetAll()
    {
        var articlecategories = _repository.GetEntities();
        return articlecategories.Select(articleCategory => new ArticleCategoryDto
        {
            Id = articleCategory.Id, 
            Title = articleCategory.Title,  
        }).OrderByDescending(x => x.Id).ToList();
    }
}