import { Component } from '@angular/core';
import { ProductHubService } from '../producthub.service';

@Component({
  selector: 'app-hikeprice',
  templateUrl: './hikeprice.component.html',
  styleUrls: ['./hikeprice.component.css']
})
export class HikepriceComponent  {
percentage:number =0;
status:boolean |undefined;
constructor(private svc:ProductHubService){}
hikePrice(id: number) {
  this.svc.hikePrice(id).subscribe((response) => {
    this.status= response;
    console.log(response);
    if (response) {
      alert("price hiked successfully")
    }
    else {
      alert("Error")
    }
  })
   
  }
}

