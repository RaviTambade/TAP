import { Component,Input } from '@angular/core';
import { OrderhubService } from '../orderhub.service';
import { Order } from '../order'
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent{
  
  @Input() order:Order | undefined;
  //order : Order | undefined
  orderId : number | undefined;

  constructor(private svc : OrderhubService){}

  
   getById(id:any):void{
     this.svc.getById(id).subscribe(
       (res)=>{
         this.orderId = res;
        console.log(res);
       }
     )

   }

  //  delete(id: any) {
  //   this.svc.delete(id).subscribe(
  //     (res) => {
  //       this.orderId=res;
  //       console.log(res);
  //   });
  // }

}

