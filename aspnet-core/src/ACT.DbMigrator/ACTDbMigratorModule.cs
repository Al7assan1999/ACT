using ACT.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ACT.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ACTEntityFrameworkCoreDbMigrationsModule),
        typeof(ACTApplicationContractsModule)
        )]
    public class ACTDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
