using AutoMapper;
using ScheduleReminder.Core.Entities;
using ScheduleReminder.Core.Repositories;
using ScheduleReminder.Service.CustomExceptions;
using ScheduleReminder.Service.Dtos;
using ScheduleReminder.Service.Dtos.ReminderDtos;
using ScheduleReminder.Service.Services.Interfaces;

namespace ScheduleReminder.Service.Services.Implementations;

public class ReminderService : IReminderService
{
    private readonly IReminderRepository _reminderRepository;
    private readonly IMapper _mapper;

    public ReminderService(IReminderRepository reminderRepository, IMapper mapper) 
    {
        _reminderRepository = reminderRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(ReminderPostDto reminderPostDto)
    {
        var reminder = _mapper.Map<Reminder>(reminderPostDto);

        await _reminderRepository.InsertAsync(reminder);
        await _reminderRepository.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var reminder = await _reminderRepository.GetAsync(x=>x.Id == id);

        if (reminder == null) throw new ReminderNotFoundException("Reminder not found");

        _reminderRepository.Remove(reminder);
        await _reminderRepository.CommitAsync();
    }

    public async Task EditAsync(int id, ReminderPostDto reminderPostDto)
    {
        var reminder = await _reminderRepository.GetAsync(x => x.Id == id);

        if (reminder == null) throw new ReminderNotFoundException("Reminder not found");

        reminder.SendAt = reminderPostDto.SendAt;
        reminder.To = reminderPostDto.To;
        reminder.Content = reminderPostDto.Content;
        reminder.Method = reminderPostDto.Method;

        await _reminderRepository.CommitAsync();
    }

    public async Task<PagenatedListDto<ReminderListItemDto>> GetAllFiltered(int page, string method)
    {
        if (page < 1) throw new PageIndexFormatException("Page index cannot be below 1");
        
        IEnumerable<Reminder> reminders = await _reminderRepository.GetAllPagenatedAsync(x => string.IsNullOrWhiteSpace(method) ? true : x.Method.ToLower() == method.ToLower(),page,10);

        int totalCount = await _reminderRepository.GetTotalCountAsync(x => x.Method.ToLower() == method.ToLower());

        List<ReminderListItemDto> itemDtos = _mapper.Map<List<ReminderListItemDto>>(reminders);

        PagenatedListDto<ReminderListItemDto> pagenatedListDto = new PagenatedListDto<ReminderListItemDto>(itemDtos,totalCount,page,10);

        return pagenatedListDto;
    }

    public async Task<IEnumerable<ReminderListItemDto>> GetAllAsync()
    {
        var reminders = await _reminderRepository.GetAllAsync(x=> x.Content!=null);
        var reminderDtos = new List<ReminderListItemDto>();

        foreach (var reminder in reminders)
        {
            reminderDtos.Add(_mapper.Map<ReminderListItemDto>(reminder));
        }

        return reminderDtos;
    }


    public async Task<ReminderDetailDto> GetByIdAsync(int id)
    {
        var reminder = await _reminderRepository.GetAsync(x=> x.Id == id);

        if (reminder == null) throw new ReminderNotFoundException($"{id} ID-li Reminder not found!");

        return _mapper.Map<ReminderDetailDto>(reminder);
    }
}
