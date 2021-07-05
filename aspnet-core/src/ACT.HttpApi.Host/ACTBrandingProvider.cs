using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ACT
{
    [Dependency(ReplaceServices = true)]
    public class ACTBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ACT";
    }
}
