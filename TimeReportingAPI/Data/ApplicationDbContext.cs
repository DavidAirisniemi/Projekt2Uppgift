using Microsoft.EntityFrameworkCore;

namespace TimeReportingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<TimeAndDate> TimeAndDate { get; set; }
    }
}
