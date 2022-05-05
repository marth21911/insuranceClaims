using Microsoft.EntityFrameworkCore;
namespace insuranceClaims.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}
        public DbSet<User> Users {get;set;}
        public DbSet<OriginalInventory> LostItems {get;set;}
        public DbSet<NewInventory> ReplacedItems {get;set;}
    }
}