using Synapse.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Synapse.Permissions;

public class SynapsePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SynapsePermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(SynapsePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SynapseResource>(name);
    }
}
