
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_API_Project.Models
{
   [Table("Authors")] 
    public class Authors
    {
        [Key]
        public int A_ID { get; set; }
        public string A_Name { get; set; }
        public int A_AGE { get; set; }
        public string A_Address { get; set; }
    }
}
