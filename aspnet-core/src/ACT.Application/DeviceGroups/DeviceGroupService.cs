using ACT.Devices;
using ACT.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ACT.DeviceGroups
{
    [Authorize(ACTPermissions.DeviceGroups.Default)]
    public class DeviceGroupService : ACTAppService, IDeviceGroupService
    {
        private readonly IDeviceGroupRepository _deviceGroupRepository;
        private readonly DeviceGroupManager _deviceGroupManager;

        public DeviceGroupService(IDeviceGroupRepository deviceGroupRepository, DeviceGroupManager deviceGroupManager)
        {
            _deviceGroupRepository = deviceGroupRepository;
            _deviceGroupManager = deviceGroupManager;
        }

        public async Task<DeviceGroupDto> GetAsync(Guid id)
        {
            var deviceGroup = await _deviceGroupRepository.GetAsync(id);
            return ObjectMapper.Map<DeviceGroup, DeviceGroupDto>(deviceGroup);
        }

        public async Task<PagedResultDto<DeviceGroupDto>> GetListAsync(GetDeviceGroupListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(DeviceGroup.Name);
            }

            var deviceGroups = await _deviceGroupRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _deviceGroupRepository.CountAsync()
                : await _deviceGroupRepository.CountAsync(
                    devicegroup => devicegroup.Name.Contains(input.Filter));

            return new PagedResultDto<DeviceGroupDto>(
                totalCount,
                ObjectMapper.Map<List<DeviceGroup>, List<DeviceGroupDto>>(deviceGroups)
            );
        }

        [Authorize(ACTPermissions.DeviceGroups.Create)]
        public async Task<DeviceGroupDto> CreateAsync(CreateDeviceGroupDto input)
        {
            var deviceGroup = await _deviceGroupManager.CreateAsync(
                input.Name
            );

            await _deviceGroupRepository.InsertAsync(deviceGroup);

            return ObjectMapper.Map<DeviceGroup, DeviceGroupDto>(deviceGroup);
        }

        [Authorize(ACTPermissions.DeviceGroups.Edit)]
        public async Task UpdateAsync(Guid id, UpdateDeviceGroupDto input)
        {
            var deviceGroup = await _deviceGroupRepository.GetAsync(id);

            if (deviceGroup.Name != input.Name)
            {
                await _deviceGroupManager.ChangeNameAsync(deviceGroup, input.Name);
            }

            await _deviceGroupRepository.UpdateAsync(deviceGroup);
        }

        [Authorize(ACTPermissions.DeviceGroups.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _deviceGroupRepository.DeleteAsync(id);
        }
    }
}
