// using Microsoft.EntityFrameworkCore;
// using Models;

// namespace Repository
// {

//     public class _DbContext : DbContext
//     {
//         public _DbContext(DbContextOptions<_DbContext> options) : base(options) { }
//         public DbSet<User> Users { get; set; }
//         public DbSet<UserLogin> UserLogins { get; set; }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             modelBuilder.Entity<UserLogin>()
//                 .HasOne(e => e.User)
//                 .WithOne(e => e.Login);
//             // .HasForeignKey<User>(e=>e.LoginId);

//         }
//     }

// }