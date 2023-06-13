using Microsoft.EntityFrameworkCore;

namespace Template
{
    public class AppDBContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Car2> Cars { get; set; }

        //public AppDBContext() : base(new DbContextOptionsBuilder().UseInMemoryDatabase("df").Options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseInMemoryDatabase(databaseName: "Test");
    }
}
