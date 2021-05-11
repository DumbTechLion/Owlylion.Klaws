using System;
using Microsoft.Extensions.DependencyInjection;
using Owlylion.Klaws.Test.Services.Interfaces;
using Owlylion.Klaws.Test.Services.Services;

namespace Owlylion.Klaws.Test.Services
{
    public static class LionServiceStartup
    {
        public static IServiceCollection ConfigureLionServices(this IServiceCollection services)
            => services.AddScoped<ILionService, LionService>()
                .AddScoped<IPackService, PackService>();
    }
}
