using ACT.DeviceGroups;
using ACT.Devices;
using ACT.Users;
using AutoMapper;
using Volo.Abp.AutoMapper;

namespace ACT
{
    public class ACTApplicationAutoMapperProfile : Profile
    {
        public ACTApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<Device, DeviceDto>();
            CreateMap<CreateUpdateDeviceDto, Device>();
            CreateMap<DeviceGroup, DeviceGroupDto>();
        }
    }
}
