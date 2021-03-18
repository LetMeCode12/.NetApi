using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Models{

    public class UserLogin{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {get; set;}
        public string Login {get; set;}
        public string Password {get; set;}
        [JsonIgnore]
        public User User {get;set;}
    }

    

    public class LoginUserDbContext : DbContext
    {
        public LoginUserDbContext(DbContextOptions<LoginUserDbContext> options) : base(options) { }
        public DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLogin>()
                .HasOne(e => e.User)
                .WithOne(e => e.Login);
            // .HasForeignKey<User>(e=>e.LoginId);

        }
    }

}