using AutoMapper;
using ScheduleReminder.Service.Profiles;

namespace ScheduleReminder.API.ServiceExtensions
{
    public static class MapperServiceExtension
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            var mapConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
