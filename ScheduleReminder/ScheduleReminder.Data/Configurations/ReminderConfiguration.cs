using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleReminder.Core.Entities;

namespace ScheduleReminder.Data.Configurations;

public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
{
    public void Configure(EntityTypeBuilder<Reminder> builder)
    {
        builder.Property(x => x.To).HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Content).HasMaxLength(500).IsRequired(true);
        builder.Property(x => x.Method).HasMaxLength(8).IsRequired(true);
        builder.Property(x => x.SendAt).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
    }
}
