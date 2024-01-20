using Blog_API_Project.Models;

namespace Blog_API_Project.Repository
{
    public interface IAuthorsRepository
    {
        Task<IEnumerable<Authors>> GetAuthors();
        Task<Authors> GetAuthorsByID(int ID);
        Task<Authors> InsertAuthors(Authors objAuthors);
        Task<Authors> UpdateAuthors(Authors objAuthors);
        bool DeleteAuthors(int ID);
    }
}
