namespace ScheduleReminder.Service.Jobs.Interfaces;

public interface ISendMailJob<T>
{
    public void SendMail(DateTime sendAt, string to, string content);
}
