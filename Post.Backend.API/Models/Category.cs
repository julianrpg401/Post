using System.ComponentModel.DataAnnotations;

namespace Backend.API.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public ICollection<PostCategory> PostCategories { get; set; }
    }
}
