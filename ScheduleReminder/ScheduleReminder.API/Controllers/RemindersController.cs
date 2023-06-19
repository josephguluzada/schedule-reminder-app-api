using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleReminder.Service.Dtos.ReminderDtos;
using ScheduleReminder.Service.Services.Interfaces;

namespace ScheduleReminder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public RemindersController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReminderPostDto reminderPostDto)
        {
            await _reminderService.CreateAsync(reminderPostDto);
            return Ok(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reminderService.Delete(id);
            return Ok(200);
        }
    }
}
