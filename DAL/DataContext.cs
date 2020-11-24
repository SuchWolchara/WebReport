using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
