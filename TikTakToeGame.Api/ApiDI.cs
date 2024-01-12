using TikTakToeGame.Business.Services;
using TikTakToeGame.Entities;
using TikTakToeGame.Repositories;

namespace TikTakToeGame.Api
{
    public static class ApiDI
    {
        public static void ConfigureTikTakToeServices(this IServiceCollection services)
        { 
            services.AddTransient<IGenericRepository<Field>, GenericRepository<Field>>();
            services.AddTransient<IFieldService, FieldService>();
        }

    }
}
