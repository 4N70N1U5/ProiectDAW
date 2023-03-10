using ProiectDAW.Helpers.Utils;
using ProiectDAW.Repositories.OrdersRepository;
using ProiectDAW.Repositories.OrderVideoGamesRepository;
using ProiectDAW.Repositories.PaymentsRepository;
using ProiectDAW.Repositories.PublishersRepository;
using ProiectDAW.Repositories.UnitOfWork;
using ProiectDAW.Repositories.UsersRepository;
using ProiectDAW.Repositories.VideoGamesRepository;
using ProiectDAW.Services.OrdersService;
using ProiectDAW.Services.OrderVideoGamesService;
using ProiectDAW.Services.PaymentsService;
using ProiectDAW.Services.PublishersService;
using ProiectDAW.Services.UsersService;
using ProiectDAW.Services.VideoGameService;

namespace ProiectDAW.Helpers
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IPaymentsRepository, PaymentsRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IPublishersRepository, PublishersRepository>();
            services.AddTransient<IVideoGamesRepository, VideoGamesRepository>();
            services.AddTransient<IOrderVideoGamesRepository, OrderVideoGamesRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IPaymentsService, PaymentsService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IPublishersService, PublishersService>();
            services.AddTransient<IVideoGamesService, VideoGamesService>();
            services.AddTransient<IOrderVideoGamesService, OrderVideoGamesService>();

            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
