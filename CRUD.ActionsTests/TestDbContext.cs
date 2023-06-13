using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.ActionsTests
{
    public class TestDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseInMemoryDatabase(databaseName: "Test");
    }
}
