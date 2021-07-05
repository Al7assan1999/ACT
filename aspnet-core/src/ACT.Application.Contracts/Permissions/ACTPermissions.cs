namespace ACT.Permissions
{
    public static class ACTPermissions
    {
        public const string GroupName = "ACT";


        public static class Dashboard
        {
            public const string DashboardGroup = GroupName + ".Dashboard";
            public const string Host = DashboardGroup + ".Host";
            public const string Tenant = GroupName + ".Tenant";
        }

        // Added items
        public static class Devices
        {
            public const string Default = GroupName + ".Devices";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
        public static class DeviceGroups
        {
            public const string Default = GroupName + ".DeviceGroups";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}