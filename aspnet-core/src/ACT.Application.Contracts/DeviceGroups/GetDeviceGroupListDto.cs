using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ACT.DeviceGroups
{
    public class GetDeviceGroupListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
