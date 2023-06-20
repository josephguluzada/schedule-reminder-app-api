using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ScheduleReminder.API.ServiceExtensions;
using ScheduleReminder.Core.Repositories;
using ScheduleReminder.Data;
using ScheduleReminder.Data.Repositories;
using ScheduleReminder.Service.Dtos.ReminderDtos;
using ScheduleReminder.Service.Services.Implementations;
using ScheduleReminder.Service.Services.Interfaces;

namespace ScheduleReminder.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                   .AddFluentValidation(x=> x.RegisterValidatorsFromAssemblyContaining<ReminderPostDtoValidator>());
                   
            builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
            
            // AutoMapper service
            builder.Services.AddMapperService();

            builder.Services.AddScoped<IReminderRepository, ReminderRepository>();
            builder.Services.AddScoped<IReminderService, ReminderService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Global exception handler.
            app.AddGlobalExceptionHandlerService();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}