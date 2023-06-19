using ScheduleReminder.Core.Entities;
using ScheduleReminder.Core.Repositories;

namespace ScheduleReminder.Data.Repositories;

public class ReminderRepository : Repository<Reminder>, IReminderRepository
{
    public ReminderRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
