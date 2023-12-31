﻿
using ScheduleReminder.Service.Dtos;
using ScheduleReminder.Service.Dtos.ReminderDtos;

namespace ScheduleReminder.Service.Services.Interfaces;

public interface IReminderService
{
    Task<int> CreateAsync(ReminderPostDto reminderPostDto);
    Task<ReminderDetailDto> GetByIdAsync(int id);
    Task<IEnumerable<ReminderListItemDto>> GetAllAsync();
    Task<PagenatedListDto<ReminderListItemDto>> GetAllFiltered(int page, string method);
    Task EditAsync(int id, ReminderPostDto reminderPostDto);
    Task Delete(int id);
}
