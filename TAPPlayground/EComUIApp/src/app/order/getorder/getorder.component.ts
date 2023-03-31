import { Component,EventEmitter,Output,Input, OnInit } from '@angular/core';
import { OrderhubService } from '../orderhub.service';
import { Order } from '../order';

@Component({
  selector: 'app-getorder',
  templateUrl: './getorder.component.html',
  styleUrls: ['./getorder.component.css']
})
export class GetorderComponent implements OnInit{

@Input() orderId : number | undefined;
order: Order   | undefined;

@Output() sendOrder = new EventEmitter();

constructor(private svc : OrderhubService) {}

ngOnInit(): void {
  if(this.orderId!=undefined)
    this.svc.getById(this.orderId).subscribe((res)=>{
      this.order = res;
      this.sendOrder.emit({order:this.order});
      console.log(this.order);
     })
    }
  


getById(id:any){
  this.svc.getById(id).subscribe((res)=>{
    this.order = res;
    this.sendOrder.emit({order:this.order});
    console.log(this.order);
   })
  }
}
