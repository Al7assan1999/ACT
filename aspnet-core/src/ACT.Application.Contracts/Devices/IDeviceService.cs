using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ACT.Devices
{
    public interface IDeviceService :
        ICrudAppService< //Defines CRUD methods
            DeviceDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateDeviceDto> //Used to create/update a book
    {
        Task<ListResultDto<DeviceGroupLookupDto>> GetDeviceGroupLookupAsync();
        void ImportFile(ImportDevicesGroupDto importDevicesGroupDto);
    }
}
