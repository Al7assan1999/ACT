using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ACT.Devices
{
    public class ImportDevicesGroupDto
    {
        [Required]
        public string Path { get; set; }
        [Required]
        public string GroupName { get; set; }
    }
}
