using Backend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Models
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ReactionType> ReactionTypes { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Share> PostShares { get; set; }
        public DbSet<PostVote> PostVotes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<UserFollow> UserFollows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar nombres de tabla y columna en camelCase
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Convierte el nombre de la tabla a camelCase
                entity.SetTableName(char.ToLowerInvariant(entity.GetTableName()[0]) + entity.GetTableName().Substring(1));

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(char.ToLowerInvariant(property.Name[0]) + property.Name.Substring(1));
                }
            }

            // Índices únicos para email, userName y nombre de categoría
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Configurar la relación en UserFollow para evitar borrados en cascada
            modelBuilder.Entity<UserFollow>()
                .HasOne(uf => uf.Follower)
                .WithMany(u => u.Followings)
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFollow>()
                .HasOne(uf => uf.Following)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.FollowingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Asignar valores por defecto a los campos de fecha
            modelBuilder.Entity<User>()
                .Property(u => u.RegistrationDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Post>()
                .Property(p => p.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Comment>()
                .Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reaction>()
                .Property(pr => pr.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Reaction>()
                .HasOne(pr => pr.User)
                .WithMany(u => u.Reactions)
                .HasForeignKey(pr => pr.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Share>()
                .Property(ps => ps.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Share>()
                .HasOne(ps => ps.User)
                .WithMany(u => u.PostShares)
                .HasForeignKey(ps => ps.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PostVote>()
                .Property(pv => pv.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<PostVote>()
                .HasOne(pv => pv.User)
                .WithMany(u => u.PostVotes)
                .HasForeignKey(pv => pv.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PostCategory>()
                .Property(pc => pc.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
