using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ACT.DeviceGroups
{
    public interface IDeviceGroupService : IApplicationService
    {
        Task<DeviceGroupDto> GetAsync(Guid id);

        Task<PagedResultDto<DeviceGroupDto>> GetListAsync(GetDeviceGroupListDto input);

        Task<DeviceGroupDto> CreateAsync(CreateDeviceGroupDto input);

        Task UpdateAsync(Guid id, UpdateDeviceGroupDto input);

        Task DeleteAsync(Guid id);
    }
}
