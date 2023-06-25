using ScheduleReminder.Service.Jobs;
using System.Net.Mail;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleReminder.Service.Helpers;

public class MailAndTelegramSender : IBaseJob
{
    private readonly TelegramBotClient _botClient;

    public MailAndTelegramSender()
    {
        _botClient = new TelegramBotClient("6282444709:AAFY0Mh_LqeJ2FPOPXf_CfkDo4YzA-7sKcA");
    }

    public void SendMail(string to, string content)
    {
        var fromAddress = new MailAddress("yquluzade98@gmail.com");
        var toAddress = new MailAddress(to);
        const string fromPassword = "krbrgvnkggrqlrif";
        const string subject = "Reminder";
        string body = content;

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com", // Replace with your SMTP server address
            Port = 587, // Replace with the appropriate port number
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }
    }

    public void SendTelegram(string to, string content)
    {
        _botClient.SendTextMessageAsync(to, content).Wait();
    }
}
