using Diab_Advertisement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diab_Advertisement.Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
