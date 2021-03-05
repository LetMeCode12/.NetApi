using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository{

    public class UserRepository : DbContext {
        public UserRepository(DbContextOptions<UserRepository> options):base(options){}
        public DbSet<User> Users {get; set;}
    }

}