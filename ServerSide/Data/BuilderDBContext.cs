using Microsoft.EntityFrameworkCore;
using ServerSide.Model;

namespace ServerSide.Data
{
    public  class BuilderDBContext : DbContext
    {
        public BuilderDBContext(DbContextOptions<BuilderDBContext>options) : base(options)
        {
            
        }
        public DbSet<User>Users { get; set; }
        public DbSet<Build>Builds { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<Store>Stores { get; set; }
        public DbSet<Price>Prices { get; set; }
        public DbSet<Category>Categories { get; set; }
         
    }
}