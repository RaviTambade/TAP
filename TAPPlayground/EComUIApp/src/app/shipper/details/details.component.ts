import { Component,OnInit } from '@angular/core';
import { ShipperhubService } from '../shipperhub.service';
import { Shipper } from '../shipper';

@Component({
  selector: 'detailsshipper',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  shipper: Shipper| undefined ;
  shipperId: number | undefined ;


  constructor(private svc:ShipperhubService){

  }
  ngOnInit(): void {
  }
  getById(Shipperid:any):void{
  this.svc.getById(Shipperid).subscribe(
    (res)=>{
      this.shipper = res;
      console.log(res);
    }
  )
  }
}
