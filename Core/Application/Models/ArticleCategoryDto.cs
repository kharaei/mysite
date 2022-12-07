using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleCategoryDto: BaseDto<int>, IDto
{ 
    public string Title { get; set; }    
} 