namespace ScheduleReminder.Service.CustomExceptions;

public class ReminderNotFoundException : Exception
{
    public ReminderNotFoundException(string message) : base(message)
    {
        
    }
}
