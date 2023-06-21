using Hangfire;
using ScheduleReminder.Service.Jobs.Interfaces;

namespace ScheduleReminder.Service.Jobs.Implementations;

public class ReminderJob<T> : IReminderJob<T> where T : IBaseJob
{
    public void Remind(DateTime sendAt, string to,string content, string method)
    {
        var sendDate = sendAt;
        var delay = sendDate - DateTime.UtcNow;

        if(method.ToLower() == "email")
            BackgroundJob.Schedule<T>(x=> x.SendMail(to,content), delay);
        else
            BackgroundJob.Schedule<T>(x => x.SendTelegram(to, content), delay);
    }
}
