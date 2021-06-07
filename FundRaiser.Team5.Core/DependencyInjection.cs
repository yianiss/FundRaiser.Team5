using FundRaiser.Team5.Core.Interfaces;
using FundRaiser.Team5.Core.Services;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FundRaiser.Team5.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IStatusUpdateService, StatusUpdateService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IProjectService, ProjectService>();

            services.AddScoped<IUserFundingPackageService, UserFundingPackageService>();

            services.AddScoped<IFundingPackageService, FundingPackageService>();

            services.AddScoped<IImagePathService, ImagePathService>();

            services.AddScoped<IVideoPathService, VideoPathService>();

            return services;
        }
    }
}
