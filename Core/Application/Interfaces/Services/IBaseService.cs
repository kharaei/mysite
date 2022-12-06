
namespace  Kharaei.Application;

public interface IBaseService<TDto>
{ 
    List<TDto> Entities();
    TDto Entity(int id);
    //void Creat(TDto entity);
    //void Update(TDto entiry);
    //void DeleteEntity();
}