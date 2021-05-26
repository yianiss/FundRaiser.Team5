using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser_Team5.Interfaces;
using FundRaiser_Team5.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FundRaiser_Team5
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IStatusUpdateService, StatusUpdateService>();

            return services;
        }
    }
}
