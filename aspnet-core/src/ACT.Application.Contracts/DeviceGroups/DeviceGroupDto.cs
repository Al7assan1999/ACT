using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ACT.DeviceGroups
{
    public class DeviceGroupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
