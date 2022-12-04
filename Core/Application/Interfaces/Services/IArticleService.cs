
namespace  Kharaei.Application;

public interface IArticleService
{ 
    List<ArticleDto> GetList();
    ArticleDto GetDetails(int id);
}