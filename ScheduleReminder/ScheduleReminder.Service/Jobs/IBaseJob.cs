namespace ScheduleReminder.Service.Jobs;

public interface IBaseJob
{
    void SendMail(string to, string content);
}
