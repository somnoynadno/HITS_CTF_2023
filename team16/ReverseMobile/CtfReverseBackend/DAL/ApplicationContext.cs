using Microsoft.EntityFrameworkCore;

namespace CtfReverseBackend.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Login)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Login = "administrator",
                    Password = "obamahamburgersussyballs",
                    IsAdmin = true
                },
                new User 
                {
                    Id = Guid.NewGuid(),
                    Login = "user",
                    Password = "password"
                });
        }
    }
}
