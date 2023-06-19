namespace ScheduleReminder.Core.Entities;

public class Reminder : BaseEntity
{
    public string To { get; set; }
    public string Content { get; set; }
    public string Method { get; set; }
    public DateTime SendAt { get; set; }
}
