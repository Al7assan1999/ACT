using ACT.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ACT
{
    [DependsOn(
        typeof(ACTEntityFrameworkCoreTestModule)
        )]
    public class ACTDomainTestModule : AbpModule
    {

    }
}