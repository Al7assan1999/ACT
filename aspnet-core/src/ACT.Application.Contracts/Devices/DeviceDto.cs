using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ACT.Devices
{
    public class DeviceDto : AuditedEntityDto<Guid>
    {
        public string IMEI { get; set; }
        public string SIM { get; set; }
        public string SerialNumber { get; set; }
        public Guid DeviceGroupId { get; set; }
        public string DeviceGroupName { get; set; }
    }
}
