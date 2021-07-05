using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ACT.Devices
{
    public class Device : AuditedAggregateRoot<Guid>
    {
        public string IMEI { get; set; }
        public string SIM { get; set; }
        public string SerialNumber { get; set; }
        public Guid DeviceGroupId { get; set; }
    }
}
