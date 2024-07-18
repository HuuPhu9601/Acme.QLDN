using Volo.Abp.Settings;

namespace Acme.QLDN.Settings;

public class QLDNSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(QLDNSettings.MySetting1));
    }
}
