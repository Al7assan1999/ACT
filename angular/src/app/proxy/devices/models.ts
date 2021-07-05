import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateDeviceDto {
  imei: string;
  sim: string;
  serialNumber: string;
}

export interface DeviceDto extends AuditedEntityDto<string> {
  imei?: string;
  sim?: string;
  serialNumber?: string;
}
