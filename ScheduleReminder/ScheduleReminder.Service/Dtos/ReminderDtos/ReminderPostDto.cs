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
        RuleFor(x => x.To).MaximumLength(100).MinimumLength(6).Must(BeValidEmailOrTelegramId).WithMessage("To must be email address or telegram id!").NotEmpty();
        RuleFor(x => x.Content).MaximumLength(500).MinimumLength(1).NotEmpty();
        RuleFor(x => x.Method).MaximumLength(8).MinimumLength(5).Must(x => x.ToLower().Equals("email") || x.ToLower().Equals("telegram")).WithMessage("Method must be email or telegram!").NotEmpty();
    }

    private bool BeValidEmailOrTelegramId(string to)
    {
        bool isValidEmail = new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(to);
        if (isValidEmail)
        {
            return true;
        }

        bool isValidTelegramId = to.Length == 10 ? true : false;

        return isValidTelegramId;
    }
}
