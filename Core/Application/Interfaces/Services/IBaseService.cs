
namespace  Kharaei.Application;

public interface IBaseService<TDto>
{ 
    List<TDto> Entities();
    TDto Entity(int id);
    void Add(TDto entity);
    //void Update(TDto entiry);
    //void DeleteEntity();
}