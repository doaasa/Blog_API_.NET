using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_API_Project.Models
{
    [Table("Article")]
    public class Article
    {
        [Key]
        public int Ar_ID { get; set; }
        public string Ar_Name { get; set; }
        public string Ar_Content { get; set; }

        public int Ar_AuthorID { get; set; }
    }
}
