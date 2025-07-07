using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Vidly.Data
{
    public class AppDbConnection : DbContext

    {
        public AppDbConnection(DbContextOptions<AppDbConnection> Options) : base (Options) { }
        public DbSet<CategoryMaster> CategoryMaster { get; set; }
        public DbSet<ProductMaster> ProductMaster { get; set; }
    }
}

