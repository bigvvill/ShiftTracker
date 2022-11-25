using Microsoft.EntityFrameworkCore;
using ShiftTracker.Entities;

namespace ShiftTracker.Data
{
    public class ShiftTrackerDbContext : DbContext
    {
        public ShiftTrackerDbContext(DbContextOptions<ShiftTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shift> Shifts { get; set; }
    }
}
