import { Component } from '@angular/core';
import { ProductHubService } from '../producthub.service';

@Component({
  selector: 'app-hikeprice',
  templateUrl: './hikeprice.component.html',
  styleUrls: ['./hikeprice.component.css']
})
export class HikepriceComponent  {
percentage:number |undefined;
status:boolean |undefined;
constructor(private svc:ProductHubService){}
hikePrice(id: any) {
  this.svc.hikePrice(id).subscribe((response) => {
    this.status= response;
    console.log(response);
    if (response) {
      window.location.reload();
      alert("price hiked successfully")
    }
    else {
      alert("Error")
    }
  })
   
  }
}

