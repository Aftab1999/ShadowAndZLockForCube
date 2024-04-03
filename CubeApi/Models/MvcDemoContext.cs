using Microsoft.EntityFrameworkCore;

namespace MvcDemo.Models
{
    public class MvcDemoContext : DbContext
    {
        public MvcDemoContext(DbContextOptions<MvcDemoContext> options)
            : base(options)
        {  
        }

        public DbSet<Cube> Cube { get; set; }
    }
}
