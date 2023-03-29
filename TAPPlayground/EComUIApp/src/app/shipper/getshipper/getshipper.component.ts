import { Component,EventEmitter,Output } from '@angular/core';
import { Shipper } from '../shipper';
import { ShipperhubService } from '../shipperhub.service';

@Component({
  selector: 'getshipper',
  templateUrl: './getshipper.component.html',
  styleUrls: ['./getshipper.component.css']
})
export class GetShipperComponent {

    shipperId: number | undefined;
    shipper: Shipper | undefined;
  
    @Output() sendShipper =new EventEmitter();
    constructor(private svc: ShipperhubService) { }
  
    getShipperById(id: any) {
      this.svc.getById(id).subscribe((response) => {
        this.shipper = response;
        this.sendShipper.emit({shipper:this.shipper});
        console.log(this.shipper);
      })
  
    }
  }


