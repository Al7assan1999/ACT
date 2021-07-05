using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ACT.EntityFrameworkCore
{
    [DependsOn(
        typeof(ACTEntityFrameworkCoreModule)
        )]
    public class ACTEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ACTMigrationsDbContext>();
        }
    }
}
