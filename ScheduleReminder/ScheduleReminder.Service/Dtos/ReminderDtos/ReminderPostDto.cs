using FluentValidation;

namespace ScheduleReminder.Service.Dtos.ReminderDtos;

public class ReminderPostDto
{
    public string To { get; set; }
    public string Content { get; set; }
    public string Method { get; set; }
    public DateTime SendAt { get; set; }
}

public class ReminderPostDtoValidator : AbstractValidator<ReminderPostDto>
{
    public ReminderPostDtoValidator()
    {
        RuleFor(x => x.To).MaximumLength(100).MinimumLength(6).EmailAddress().WithMessage("Must be valid email address!").NotEmpty();
        RuleFor(x => x.Content).MaximumLength(500).MinimumLength(1).NotEmpty();
        RuleFor(x => x.Method).MaximumLength(8).MinimumLength(5).Must(x=> x.ToLower().Equals("email") || x.ToLower().Equals("telegram")).WithMessage("Method must be email or telegram!").NotEmpty();
    }
}
