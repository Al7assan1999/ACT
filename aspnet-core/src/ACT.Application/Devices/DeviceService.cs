using ACT.DeviceGroups;
using ACT.Permissions;
using Microsoft.AspNetCore.Authorization;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace ACT.Devices
{
    [Authorize(ACTPermissions.Devices.Default)]
    public class DeviceService :
        CrudAppService<
            Device, //The Book entity
            DeviceDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateDeviceDto>, //Used to create/update a book
        IDeviceService //implement the IBookAppService
    {
        private readonly IDeviceGroupRepository _deviceGroupRepository;
        private readonly DeviceGroupManager _deviceGroupManager;
        public DeviceService(
            IRepository<Device, Guid> repository,
            IDeviceGroupRepository deviceGroupRepository,
            DeviceGroupManager deviceGroupManager)
            : base(repository)
        {
            _deviceGroupRepository = deviceGroupRepository;
            _deviceGroupManager = deviceGroupManager;
            GetPolicyName = ACTPermissions.Devices.Default;
            GetListPolicyName = ACTPermissions.Devices.Default;
            CreatePolicyName = ACTPermissions.Devices.Create;
            UpdatePolicyName = ACTPermissions.Devices.Edit;
            DeletePolicyName = ACTPermissions.Devices.Delete;
        }

        public override async Task<DeviceDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from device in queryable
                        join deviceGroup in _deviceGroupRepository on device.DeviceGroupId equals deviceGroup.Id
                        where device.Id == id
                        select new { device, deviceGroup };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Device), id);
            }

            var deviceDto = ObjectMapper.Map<Device, DeviceDto>(queryResult.device);
            deviceDto.DeviceGroupName = queryResult.deviceGroup.Name;
            return deviceDto;
        }

        public override async Task<PagedResultDto<DeviceDto>>
            GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from device in queryable
                        join deviceGroup in _deviceGroupRepository on device.DeviceGroupId equals deviceGroup.Id
                        select new { device, deviceGroup };

            query = query
                .OrderBy(q => q.deviceGroup.Name)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var deviceDtos = queryResult.Select(x =>
            {
                var deviceDto = ObjectMapper.Map<Device, DeviceDto>(x.device);
                deviceDto.DeviceGroupName = x.deviceGroup.Name;
                return deviceDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<DeviceDto>(
                totalCount,
                deviceDtos
            );
        }


        public async Task<ListResultDto<DeviceGroupLookupDto>> GetDeviceGroupLookupAsync()
        {
            var deviceGroups = await _deviceGroupRepository.GetListAsync();

            return new ListResultDto<DeviceGroupLookupDto>(
                ObjectMapper.Map<List<DeviceGroup>, List<DeviceGroupLookupDto>>(deviceGroups)
            );
        }

        public async void ImportFile(ImportDevicesGroupDto input)
        {
            var ep = new ExcelPackage(new FileInfo(input.Path));
            var ws = ep.Workbook.Worksheets["Sheet1"];
            var domains = new string[1000,1000];
            for (int rw = 0; rw <= ws.Dimension.End.Row - 2; rw++)
                for(int col = 0; col <= ws.Dimension.End.Column - 1; col++)
                    if (ws.Cells[rw + 2, col + 1].Value != null)
                        domains[rw, col] = ws.Cells[rw + 2, col + 1].Value.ToString();


            using (FileStream fs = File.Create("C:\\Users\\Airmon-Ng\\Desktop\\Preview.txt"))
            {
                Byte[] title;
                for (int i = 0; i <= ws.Dimension.End.Row - 2; i++)
                {
                    for (int j = 0; j <= ws.Dimension.End.Column - 1; j++)
                    {
                        title = new UTF8Encoding(true).GetBytes(domains[i,j] + "\t");
                        fs.Write(title, 0, title.Length);
                    }
                    title = new UTF8Encoding(true).GetBytes("\n");
                    fs.Write(title, 0, title.Length);
                }
            }
            var deviceGroup = await _deviceGroupRepository.InsertAsync(
                   await _deviceGroupManager.CreateAsync(
                       input.GroupName
                       )
                   );
            for (int i = 0; i <= ws.Dimension.End.Row - 2; i++)
            {
                var newDevice = new Device()
                {
                    DeviceGroupId = deviceGroup.Id,
                    IMEI = domains[i, 0],
                    SIM = domains[i, 1],
                    SerialNumber = domains[i, 2],
                };
                await Repository.InsertAsync(newDevice);
            }
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"device.{nameof(Device.IMEI)}";
            }

            if (sorting.Contains("deviceGroupName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "deviceGroupName",
                    "deviceGroup.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"device.{sorting}";
        }
    }
}
