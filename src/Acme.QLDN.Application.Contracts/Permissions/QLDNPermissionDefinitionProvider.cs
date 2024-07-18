using Acme.QLDN.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.QLDN.Permissions;

public class QLDNPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(QLDNPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(QLDNPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QLDNResource>(name);
    }
}
