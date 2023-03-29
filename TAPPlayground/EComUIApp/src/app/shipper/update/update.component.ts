import { Component } from '@angular/core';
import { Shipper } from '../shipper';
import { ShipperhubService } from '../shipperhub.service';

@Component({
  selector: 'updateshipper',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent {
    shipper: Shipper | any;
    status: boolean | undefined;
  
  
    constructor(private svc: ShipperhubService) { }
  
    updateShipper() {
      this.svc.UpdateShipper(this.shipper).subscribe((response) => {
        this.status = response;
        console.log(response);
      })
    }
    receiveShipper($event: any) {
      this.shipper = $event.shipper
    }
  
  }

