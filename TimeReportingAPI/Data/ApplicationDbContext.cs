using Microsoft.EntityFrameworkCore;

namespace TimeReportingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeAndDate> TimesAndDates { get; set; }
    }
}
