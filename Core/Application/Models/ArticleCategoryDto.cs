using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleCategorySelectDto: BaseDto<ArticleCategorySelectDto, ArticleCategory, int>
{ 
    public string Title { get; set; }     
} 

public class ArticleCategoryDto:BaseDto<ArticleCategoryDto, ArticleCategory, int>
{ 
    public string Title { get; set; }    
    public int ParentCategoryId { get; set; }   
} 