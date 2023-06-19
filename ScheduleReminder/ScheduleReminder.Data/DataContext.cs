using Microsoft.EntityFrameworkCore;
using ScheduleReminder.Core.Entities;
using ScheduleReminder.Data.Configurations;

namespace ScheduleReminder.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){}

    public DbSet<Reminder> Reminders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReminderConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
