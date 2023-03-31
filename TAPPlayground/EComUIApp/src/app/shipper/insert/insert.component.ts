import { Component, OnInit} from '@angular/core';
import { Shipper } from '../shipper';
import { ShipperhubService } from '../shipperhub.service';

@Component({
  selector: 'insertShipper',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertShipperComponent{
    shipper:Shipper = {
    shipperId: 0,
    companyName: "",
    contactNumber: 0,
    email:"",
    accountNumber: 0,
  };
  status: boolean | undefined;
 
 constructor(private svc:ShipperhubService){}
 

  insertShipper(form:any){
    this.svc.insertShipper(form).subscribe(
      (response)=>{
        this.status=response;
        console.log(response);
  }
  )
  }
}
