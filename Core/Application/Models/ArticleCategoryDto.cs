using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleCategorySelectDto: BaseDto<int>, IDto
{ 
    public string Title { get; set; }     
} 

public class ArticleCategoryDto: BaseDto<int>, IDto
{ 
    public string Title { get; set; }    
    public int ParentCategoryId { get; set; }   
} 