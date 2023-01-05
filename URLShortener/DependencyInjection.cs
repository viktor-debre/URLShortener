using URLShortener.DAO.Interfaces;
using URLShortener.DAO.Repositories;
using URLShortener.Services.Interfaces;
using URLShortener.Services.Realization;

namespace URLShortener
{
    public static class DependencyInjection
    {
        public static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IURLRepository, URLRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IURLService, URLService>();
        }
    }
}
