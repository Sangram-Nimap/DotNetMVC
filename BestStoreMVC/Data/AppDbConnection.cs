using BestStoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BestStoreMVC.Data
{
    public class AppDbConnection : DbContext
    {
        public AppDbConnection(DbContextOptions<AppDbConnection> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

    }

}
