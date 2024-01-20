using Blog_API_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_API_Project.Repository
{
    public class AuthorsRepository:IAuthorsRepository
    {
        private readonly BlogAPI _appDBContext;
        public AuthorsRepository(BlogAPI context)
        {
            _appDBContext = context ??
           throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Authors>> GetAuthors()
        {
            return await _appDBContext.Authorss.ToListAsync();
        }
        public async Task<Authors> GetAuthorsByID(int ID)
        {
            return await _appDBContext.Authorss.FindAsync(ID);
        }
        public async Task<Authors> InsertAuthors(Authors objAuthors)
        {
            _appDBContext.Authorss.Add(objAuthors);
            await _appDBContext.SaveChangesAsync();
            return objAuthors;
        }
        public async Task<Authors> UpdateAuthors(Authors objAuthors)
        {
            _appDBContext.Entry(objAuthors).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objAuthors;
        }
        public bool DeleteAuthors(int ID)
        {
            bool result = false;
            var AID = _appDBContext.Authorss.Find(ID);
            if (AID != null)
            {
                _appDBContext.Entry(AID).State = EntityState.Deleted;
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

