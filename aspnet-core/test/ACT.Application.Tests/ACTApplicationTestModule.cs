using Volo.Abp.Modularity;

namespace ACT
{
    [DependsOn(
        typeof(ACTApplicationModule),
        typeof(ACTDomainTestModule)
        )]
    public class ACTApplicationTestModule : AbpModule
    {

    }
}