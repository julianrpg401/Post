using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.API.Models
{
    public class PostImage
    {
        [Key]
        public int PostImageId { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required, MaxLength(500)]
        public string ImageUrl { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
