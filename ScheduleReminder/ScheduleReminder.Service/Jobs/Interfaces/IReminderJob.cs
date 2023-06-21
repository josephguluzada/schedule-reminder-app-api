namespace ScheduleReminder.Service.Jobs.Interfaces;

public interface IReminderJob<T>
{
    public void Remind(DateTime sendAt, string to, string content,string method);
}
