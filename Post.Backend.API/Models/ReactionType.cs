using System.ComponentModel.DataAnnotations;

namespace Backend.API.Models
{
    public class ReactionType
    {
        [Key]
        public int ReactionTypeId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string IconUrl { get; set; }

        public ICollection<Reaction>? Reactions { get; set; }
    }
}
