using AutoMapper;
using Kharaei.Domain; 

namespace Kharaei.Api;

public class CategoryDto : BaseDto<CategoryDto, Category>
{
    public string Name { get; set; }   
    //public int ParentCategoryId { get; set; }
    
}

public class CategorySelectDto : BaseDto<CategorySelectDto, Category>
{
    public string Name { get; set; }   
    public string ParentName { get; set; }
}