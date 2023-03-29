import { Component,EventEmitter,Output } from '@angular/core';
import { OrderhubService } from '../orderhub.service';
import { Order } from '../order';

@Component({
  selector: 'app-getorder',
  templateUrl: './getorder.component.html',
  styleUrls: ['./getorder.component.css']
})
export class GetorderComponent {

orderId:number | undefined;
order: Order   | undefined;

@Output() sendOrder = new EventEmitter();

constructor(private svc : OrderhubService) {}

getById(id:any){
  this.svc.getById(id).subscribe((res)=>{
    this.order = res;
    this.sendOrder.emit({order:this.order});
    console.log(this.order);
   })
  }
}
