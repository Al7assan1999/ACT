using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ACT.DeviceGroups
{
    public class CreateDeviceGroupDto
    {
        [Required]
        [StringLength(DeviceGroupConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}
