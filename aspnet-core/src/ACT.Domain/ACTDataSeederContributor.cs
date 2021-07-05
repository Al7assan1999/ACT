using ACT.DeviceGroups;
using ACT.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ACT
{
    public class ACTDataSeederContributor 
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Device, Guid> _deviceRepository;
        private readonly IDeviceGroupRepository _deviceGroupRepository;
        private readonly DeviceGroupManager _deviceGroupManager;

        public ACTDataSeederContributor(
            IRepository<Device, Guid> deviceRepository, 
            IDeviceGroupRepository deviceGroupRepository, 
            DeviceGroupManager deviceGroupManager)
        {
            _deviceRepository = deviceRepository;
            _deviceGroupRepository = deviceGroupRepository;
            _deviceGroupManager = deviceGroupManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _deviceRepository.GetCountAsync() > 0)
            {
                return;
            }

            var deviceGroup1 = await _deviceGroupRepository.InsertAsync(
                    await _deviceGroupManager.CreateAsync(
                        "DeviceGroup1"
                        )
                    );

            var deviceGroup2 = await _deviceGroupRepository.InsertAsync(
                    await _deviceGroupManager.CreateAsync(
                        "DeviceGroup2"
                        )
                    );

            await _deviceRepository.InsertAsync(
                new Device
                {
                    DeviceGroupId = deviceGroup1.Id,
                    IMEI = "IMEI1",
                    SIM = "SIM1",
                    SerialNumber = "SerialNumber1"
                },
                autoSave: true
            );

                await _deviceRepository.InsertAsync(
                new Device
                {
                    DeviceGroupId = deviceGroup1.Id,
                    IMEI = "IMEI2",
                    SIM = "SIM2",
                    SerialNumber = "SerialNumber1"
                },
                autoSave: true
            );

                await _deviceRepository.InsertAsync(
                    new Device
                    {
                        DeviceGroupId = deviceGroup2.Id,
                        IMEI = "IMEI3",
                        SIM = "SIM3",
                        SerialNumber = "SerialNumber2"
                    },
                    autoSave: true
                );

        }
    }
}
