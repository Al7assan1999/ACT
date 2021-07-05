using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ACT.Devices
{
    public class DeviceGroupLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
