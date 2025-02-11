using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.API.Models
{
    public class PostCategory
    {
        [Key]
        public int PostCategoryId { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
