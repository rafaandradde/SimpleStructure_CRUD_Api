using Microsoft.EntityFrameworkCore;
using Simple.ProductApi.Entities;

namespace Simple.ProductApi.Context
{
    public class MySqlContext : DbContext
    {

        public MySqlContext() { }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

    }
}
