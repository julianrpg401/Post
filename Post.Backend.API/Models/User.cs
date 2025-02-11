using System.ComponentModel.DataAnnotations;

namespace Backend.API.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(10)]
        public string CountryCode { get; set; }

        [Required, MaxLength(20)]
        public string Phone { get; set; }

        [Required, MaxLength(255)]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string PasswordHash { get; set; }

        public DateTime RegistrationDate { get; set; }

        [MaxLength(500)]
        public string ProfileImageUrl { get; set; }

        [MaxLength(500)]
        public string CoverImageUrl { get; set; }

        // Navegación
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
        public ICollection<Share> PostShares { get; set; }
        public ICollection<PostVote> PostVotes { get; set; }
        public ICollection<UserFollow> Followers { get; set; }      // Usuarios que le siguen
        public ICollection<UserFollow> Followings { get; set; }     // Usuarios a los que sigue
    }
}
