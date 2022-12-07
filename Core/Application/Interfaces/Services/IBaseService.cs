using Kharaei.Domain;
using Microsoft.EntityFrameworkCore;

namespace  Kharaei.Application;

public interface IBaseService<TDto>
{ 
    List<TDto> GetAll();
    TDto GetById(int id);
    void Add(TDto entity);
    //void Update(TDto entiry);
    //void DeleteEntity();
}