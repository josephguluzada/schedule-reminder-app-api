using Hangfire;
using Microsoft.AspNetCore.Mvc;
using ScheduleReminder.Service.Dtos.ReminderDtos;
using ScheduleReminder.Service.Helpers;
using ScheduleReminder.Service.Jobs.Interfaces;
using ScheduleReminder.Service.Services.Interfaces;

namespace ScheduleReminder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private readonly IReminderService _reminderService;
        private readonly IReminderJob<MailAndTelegramSender> _reminderJob;

        public RemindersController(IReminderService reminderService, IReminderJob<MailAndTelegramSender> sendMailJob)
        {
            _reminderService = reminderService;
            _reminderJob = sendMailJob;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReminderPostDto reminderPostDto)
        {
            var reminderId = await _reminderService.CreateAsync(reminderPostDto);

            var reminder = await _reminderService.GetByIdAsync(reminderId);

            _reminderJob.Remind(reminder.SendAt,reminder.To,reminder.Content,reminder.Method);

            return Ok(201);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(string? method, int page = 1) 
        { 
            return Ok(await _reminderService.GetAllFiltered(page, method));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _reminderService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ReminderPostDto reminderPostDto)
        {
            await _reminderService.EditAsync(id, reminderPostDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reminderService.Delete(id);
            return Ok();
        }
    }
}
