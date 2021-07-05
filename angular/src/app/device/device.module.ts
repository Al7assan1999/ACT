import { NgModule } from '@angular/core';
import { DeviceRoutingModule } from './device-routing.module';
import { DeviceComponent } from './device.component';


@NgModule({
  declarations: [DeviceComponent],
  imports: [
    DeviceRoutingModule,
  ]
})
export class DeviceModule { }
