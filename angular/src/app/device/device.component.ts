import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { DeviceService, DeviceDto } from '@proxy/devices';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.scss'],
  providers: [ListService],
})
export class DeviceComponent implements OnInit {
  device = { items: [], totalCount: 0 } as PagedResultDto<DeviceDto>;

  constructor(public readonly list: ListService, private deviceService: DeviceService) {}


  ngOnInit(): void {
    const deviceStreamCreator = (query) => this.deviceService.getList(query);

    this.list.hookToQuery(deviceStreamCreator).subscribe((response) => {
      this.device = response;
    });
  }

}
