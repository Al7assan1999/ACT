using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ACT.DeviceGroups
{
    public class DeviceGroup : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        private DeviceGroup()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal DeviceGroup(
            Guid id,
            [NotNull] string name)
            : base(id)
        {
            SetName(name);
            
        }
        internal DeviceGroup ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: DeviceGroupConsts.MaxNameLength
            );
        }
    }
}
