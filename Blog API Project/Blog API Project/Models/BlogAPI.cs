using Microsoft.EntityFrameworkCore;

namespace Blog_API_Project.Models
{
    public class BlogAPI:DbContext
    {
        public BlogAPI(DbContextOptions<BlogAPI> options) : base(options) { }
        public DbSet<Article> Articles
        {
            get;
            set;
        }
        public DbSet<Authors> Authorss
        {
            get;
            set;
        }
    
}
}
