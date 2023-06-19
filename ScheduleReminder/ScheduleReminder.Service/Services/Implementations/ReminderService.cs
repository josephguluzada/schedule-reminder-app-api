using ScheduleReminder.Core.Entities;
using ScheduleReminder.Core.Repositories;
using ScheduleReminder.Service.Dtos;
using ScheduleReminder.Service.Dtos.ReminderDtos;
using ScheduleReminder.Service.Services.Interfaces;

namespace ScheduleReminder.Service.Services.Implementations;

public class ReminderService : IReminderService
{
    private readonly IReminderRepository _reminderRepository;

    public ReminderService(IReminderRepository reminderRepository) 
    {
        _reminderRepository = reminderRepository;
    }

    public async Task CreateAsync(ReminderPostDto reminderPostDto)
    {
        var reminder = new Reminder { To = reminderPostDto.To, Content = reminderPostDto.Content, Method = reminderPostDto.Method, SendAt = reminderPostDto.SendAt };

        await _reminderRepository.InsertAsync(reminder);
        await _reminderRepository.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var reminder = await _reminderRepository.GetAsync(x=>x.Id == id);

        if (reminder == null) throw new NullReferenceException("Reminder not found");

        _reminderRepository.Remove(reminder);
        await _reminderRepository.CommitAsync();
    }

    public Task EditAsync(int id, ReminderPostDto reminderPostDto)
    {
        throw new NotImplementedException();
    }

    public Task<PagenatedListDto<ReminderListItemDto>> GetAllFiltered(int page, string method)
    {
        throw new NotImplementedException();
    }

    public Task<ReminderDetailDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
