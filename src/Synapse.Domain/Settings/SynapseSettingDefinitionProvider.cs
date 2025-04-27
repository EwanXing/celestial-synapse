using Volo.Abp.Settings;

namespace Synapse.Settings;

public class SynapseSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SynapseSettings.MySetting1));
    }
}
