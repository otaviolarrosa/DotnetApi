using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Postgres.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
