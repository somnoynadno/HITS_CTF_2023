using BoardApp.Services.Contracts;
using BoardApp.Services.Implementations;

namespace BoardApp.Services
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddBL(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMessageService, MessageService>();
            return services;
        }
    }
}
