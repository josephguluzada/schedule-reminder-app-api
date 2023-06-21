using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ScheduleReminder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireTestsController : ControllerBase
    {
        //TestClassHangfire _testClassHangfire = new TestClassHangfire();

        //[HttpPost]
        //public IActionResult Welcome(string message)
        //{
        //    var jobId = BackgroundJob.Enqueue(() => _testClassHangfire.Welcome(message));
        //    return Ok($"jobId: {jobId} Welcome senT {DateTimeOffset.UtcNow}");
        //}

        //[HttpPost]
        //[Route("Scheduled")]
        //public IActionResult Shceduled(string message)
        //{
        //    var sendAt = new DateTime(2023, 06, 21, 8, 48, 0);
        //    var delay = sendAt - DateTime.UtcNow;
        //    var jobId = BackgroundJob.Schedule<TestClassHangfire>(x=> x.ScheduleWelcome(message),delay);


        //    return Ok($"jobId: {jobId} Welcome senT");
        //}
    }
}
