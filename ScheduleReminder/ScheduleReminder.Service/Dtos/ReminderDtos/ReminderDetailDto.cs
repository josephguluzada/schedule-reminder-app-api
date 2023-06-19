namespace ScheduleReminder.Service.Dtos.ReminderDtos;

public class ReminderDetailDto
{
    public int Id { get; set; }
    public string To { get; set; }
    public string Content { get; set; }
    public string Method { get; set; }
    public DateTime SendAt { get; set; }
}
