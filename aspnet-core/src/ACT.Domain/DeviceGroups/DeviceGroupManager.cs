using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace ACT.DeviceGroups
{
    public class DeviceGroupManager : DomainService
    {
        private readonly IDeviceGroupRepository _deviceGroupRepository;
        public DeviceGroupManager(IDeviceGroupRepository deviceGroupRepository)
        {
            _deviceGroupRepository = deviceGroupRepository;
        }

        public async Task<DeviceGroup> CreateAsync(
            [NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingDeviceGroup = await _deviceGroupRepository.FindByNameAsync(name);
            if (existingDeviceGroup != null)
            {
                throw new DeviceGroupAlreadyExistsException(name);
            }

            return new DeviceGroup(
                GuidGenerator.Create(),
                name
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] DeviceGroup deviceGroup,
            [NotNull] string newName)
        {
            Check.NotNull(deviceGroup, nameof(deviceGroup));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingDeviceGroup = await _deviceGroupRepository.FindByNameAsync(newName);
            if (existingDeviceGroup != null && existingDeviceGroup.Id != deviceGroup.Id)
            {
                throw new DeviceGroupAlreadyExistsException(newName);
            }

            deviceGroup.ChangeName(newName);
        }
    }
}
