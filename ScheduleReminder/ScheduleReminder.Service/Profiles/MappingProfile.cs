using AutoMapper;
using ScheduleReminder.Core.Entities;
using ScheduleReminder.Service.Dtos.ReminderDtos;

namespace ScheduleReminder.Service.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Reminder, ReminderDetailDto>();
        CreateMap<Reminder, ReminderListItemDto>();
        CreateMap<ReminderPostDto, Reminder>();
    }
}
