using Blog_API_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_API_Project.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly BlogAPI _appDBContext;

        public ArticleRepository(BlogAPI context)
        {
            _appDBContext = context ??
           throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Article>> GetArticle()
        {
            return await _appDBContext.Articles.ToListAsync();
        }
        public async Task<Article> GetArticleByID(int ID)
        {
            return await _appDBContext.Articles.FindAsync(ID);
        }
        public async Task<Article> InsertArticle(Article objArticle)
        {
            _appDBContext.Articles.Add(objArticle);
            await _appDBContext.SaveChangesAsync();
            return objArticle;
        }
        public async Task<Article> UpdateArticle(Article objArticle)
        {
            _appDBContext.Entry(objArticle).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objArticle;
        }
        public bool DeleteArticle(int ID)
        {
            bool result = false;
            var Article = _appDBContext.Articles.Find(ID);
            if (Article != null)
            {
                _appDBContext.Entry(Article).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

    }

}
