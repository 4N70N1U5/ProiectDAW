using ProiectDAW.Helpers.Utils;
using ProiectDAW.Repositories.OrdersRepository;
using ProiectDAW.Repositories.PaymentsRepository;
using ProiectDAW.Repositories.UsersRepository;
using ProiectDAW.Services.OrdersService;
using ProiectDAW.Services.PaymentsService;
using ProiectDAW.Services.UsersService;

namespace ProiectDAW.Helpers
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IPaymentsRepository, PaymentsRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IPaymentsService, PaymentsService>();
            services.AddTransient<IOrdersService, OrdersService>();

            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
