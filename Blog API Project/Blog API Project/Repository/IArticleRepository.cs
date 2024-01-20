using Blog_API_Project.Models;

namespace Blog_API_Project.Repository
{
    public interface IArticleRepository
    {
      
            Task<IEnumerable<Article>> GetArticle();
            Task<Article> GetArticleByID(int ID);
            Task<Article> InsertArticle(Article objArticle);
            Task<Article> UpdateArticle(Article objArticle);
            bool DeleteArticle(int ID);
       
    }
}
