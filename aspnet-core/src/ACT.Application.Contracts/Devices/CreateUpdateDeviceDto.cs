using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ACT.Devices
{
    public class CreateUpdateDeviceDto
    {
        [Required]
        public string IMEI { get; set; }
        [Required]
        public string SIM { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public Guid DeviceGroupId { get; set; }
    }
}
