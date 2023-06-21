using Hangfire;
using ScheduleReminder.Service.Jobs.Interfaces;

namespace ScheduleReminder.Service.Jobs.Implementations;

public class SendMailJob<T> : ISendMailJob<T> where T : IBaseJob
{
    public void SendMail(DateTime sendAt, string to,string content)
    {
        var sendDate = sendAt;
        var delay = sendDate - DateTime.UtcNow;
        BackgroundJob.Schedule<T>(x=> x.SendMail(to,content), delay);
    }
}
