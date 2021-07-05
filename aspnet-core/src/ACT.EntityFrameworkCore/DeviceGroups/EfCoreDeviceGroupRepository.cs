using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using ACT.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ACT.DeviceGroups
{
    public class EfCoreDeviceGroupRepository
        : EfCoreRepository<ACTDbContext, DeviceGroup, Guid>,
            IDeviceGroupRepository
    {
        public EfCoreDeviceGroupRepository(
           IDbContextProvider<ACTDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task<DeviceGroup> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(deviceGroup => deviceGroup.Name == name);
        }

        public async Task<List<DeviceGroup>> GetListAsync(
           int skipCount,
           int maxResultCount,
           string sorting,
           string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    deviceGroup => deviceGroup.Name.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
