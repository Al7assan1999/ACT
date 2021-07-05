using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ACT.DeviceGroups
{
    public class DeviceGroupAlreadyExistsException : BusinessException
    {
        public DeviceGroupAlreadyExistsException(string name)
            : base(ACTDomainErrorCodes.DeviceGroupAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
