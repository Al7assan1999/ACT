using ACT.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace ACT.Permissions
{
    public class ACTPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var ACTGroup = context.AddGroup(ACTPermissions.GroupName, L("Permission:ACT"));

            ACTGroup.AddPermission(ACTPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            ACTGroup.AddPermission(ACTPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            var devicesPermission = ACTGroup.AddPermission(ACTPermissions.Devices.Default, L("Permission:Devices"));
            devicesPermission.AddChild(ACTPermissions.Devices.Create, L("Permission:Devices.Create"));
            devicesPermission.AddChild(ACTPermissions.Devices.Edit, L("Permission:Devices.Edit"));
            devicesPermission.AddChild(ACTPermissions.Devices.Delete, L("Permission:Devices.Delete"));

            var deviceGroupsPermission = ACTGroup.AddPermission(
                ACTPermissions.DeviceGroups.Default, L("Permission:DeviceGroups"));

            deviceGroupsPermission.AddChild(
                ACTPermissions.DeviceGroups.Create, L("Permission:DeviceGroups.Create"));

            deviceGroupsPermission.AddChild(
                ACTPermissions.DeviceGroups.Edit, L("Permission:DeviceGroups.Edit"));

            deviceGroupsPermission.AddChild(
                ACTPermissions.DeviceGroups.Delete, L("Permission:DeviceGroups.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ACTResource>(name);
        }
    }
}
