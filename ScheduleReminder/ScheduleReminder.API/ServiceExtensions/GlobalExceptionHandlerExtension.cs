using Microsoft.AspNetCore.Diagnostics;
using ScheduleReminder.Service.CustomExceptions;

namespace ScheduleReminder.API.ServiceExtensions
{
    public static class GlobalExceptionHandlerExtension
    {
        public static void AddGlobalExceptionHandlerService(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var code = 500;
                    string message = "Internal Server error!";

                    if (contextFeature != null)
                    {
                        message = contextFeature.Error.Message;
                        if (contextFeature.Error is ReminderNotFoundException)
                            code = 404;
                        else if (contextFeature.Error is PageIndexFormatException)
                            code = 400;
                    }

                    context.Response.StatusCode = code;

                    await context.Response.WriteAsync(new
                    {
                        code = code,
                        message = message
                    }.ToString());
                });
            });
        }
    }
}
