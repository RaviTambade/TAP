import { Component,EventEmitter,Input,OnInit,Output } from '@angular/core';
import { Shipper } from '../shipper';
import { ShipperhubService } from '../shipperhub.service';

@Component({
  selector: 'getshipper',
  templateUrl: './getshipper.component.html',
  styleUrls: ['./getshipper.component.css']
})
export class GetShipperComponent implements OnInit{
@Input()  shipperId: number | undefined;
    shipper: Shipper | undefined;
  
    @Output() sendShipper =new EventEmitter();
    constructor(private svc: ShipperhubService) { }
    ngOnInit(): void {
    if (this.shipperId!=undefined){
    this.svc.getById(this.shipperId).subscribe((response)=>{
      this.shipper=response;
      this.sendShipper.emit({shipper:this.shipper});
      console.log(this.shipper);
      console.log("shipperDataSend")
    })


    }

  }
  
    getShipperById(id: any) {
      this.svc.getById(id).subscribe((response) => {
        this.shipper = response;
        this.sendShipper.emit({shipper:this.shipper});
        console.log(this.shipper);
      })
  
    }
  }


