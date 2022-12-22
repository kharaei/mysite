using AutoMapper;
using Kharaei.Common;
using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleCategoryService : IArticleCategoryService
{    
    private readonly IBaseRepository<ArticleCategory> _baseRepository; 
    private readonly IMapper _mapper;

    public ArticleCategoryService(IBaseRepository<ArticleCategory> baseRepository, IMapper mapper)
    { 
        _baseRepository = baseRepository;
        _mapper = mapper;
    }
 
    public void Create(ArticleCategoryDto entity)
    {    
        var newRecord = new ArticleCategory();
        newRecord.Title = entity.Title;
        if (entity.ParentCategoryId > 0)
            newRecord.ParentCategoryId = entity.ParentCategoryId; 

        _baseRepository.Add(newRecord); 
    } 


    public List<ArticleCategorySelectDto> Read()
    {
        var articlecategories = _baseRepository.TableNoTracking.ToList(); 
        var model = _mapper.Map<List<ArticleCategorySelectDto>>(articlecategories);
        return model;
    }
    
    public ArticleCategory Read(int Id)
    {
        return _baseRepository.GetById(Id);   
    }

    public void Update(int Id, ArticleCategoryDto dto)
    {
        var model = _baseRepository.GetById(Id);
        model.Title = dto.Title;
        model.ParentCategoryId = dto.ParentCategoryId;
        _baseRepository.Update(model);
    }

    public void Delete(int Id)
    {
        var articleCategory = _baseRepository.GetById(Id);
        if (articleCategory == null)
            throw new BadRequestException("شناسه نامعتبر است.");

        _baseRepository.Delete(articleCategory);        
    }  

}