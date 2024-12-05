using Microsoft.EntityFrameworkCore;

namespace Crud_Operations_using_.NetCore_WebAPI.Models
{
    public class BrandContext : DbContext
    {
        public BrandContext(DbContextOptions<BrandContext> options):base(options)
        {
            
        }

        public DbSet<Brand> Brands { get; set; }
    }
}
