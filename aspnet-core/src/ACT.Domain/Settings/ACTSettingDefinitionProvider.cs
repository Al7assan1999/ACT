using Volo.Abp.Settings;

namespace ACT.Settings
{
    public class ACTSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ACTSettings.MySetting1));
        }
    }
}
