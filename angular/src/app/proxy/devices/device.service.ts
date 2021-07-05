import type { CreateUpdateDeviceDto, DeviceDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DeviceService {
  apiName = 'Default';

  create = (input: CreateUpdateDeviceDto) =>
    this.restService.request<any, DeviceDto>({
      method: 'POST',
      url: '/api/app/device',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/device/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, DeviceDto>({
      method: 'GET',
      url: `/api/app/device/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<DeviceDto>>({
      method: 'GET',
      url: '/api/app/device',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateDeviceDto) =>
    this.restService.request<any, DeviceDto>({
      method: 'PUT',
      url: `/api/app/device/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
