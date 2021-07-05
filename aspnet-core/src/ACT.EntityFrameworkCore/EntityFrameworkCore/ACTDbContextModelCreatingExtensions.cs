using ACT.DeviceGroups;
using ACT.Devices;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ACT.EntityFrameworkCore
{
    public static class ACTDbContextModelCreatingExtensions
    {
        public static void ConfigureACT(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<Device>(b =>
            {
                b.ToTable(ACTConsts.DbTablePrefix + "Devices", ACTConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //...
                b.HasOne<DeviceGroup>().WithMany().HasForeignKey(x => x.DeviceGroupId).IsRequired();
            });

            builder.Entity<DeviceGroup>(b =>
            {
                b.ToTable(ACTConsts.DbTablePrefix + "DeviceGroups",
                    ACTConsts.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(DeviceGroupConsts.MaxNameLength);

                b.HasIndex(x => x.Name);
            });
        }
    }
}