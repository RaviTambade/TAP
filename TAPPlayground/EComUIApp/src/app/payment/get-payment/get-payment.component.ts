import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Payment } from '../payment';
import { PaymenthubService } from '../paymenthub.service';

@Component({
  selector: 'app-get-payment',
  templateUrl: './get-payment.component.html',
  styleUrls: ['./get-payment.component.css']
})
export class GetPaymentComponent implements OnInit{


payment:Payment |undefined;


@Input() paymentId:number|undefined;
@Output() sendPayment=new EventEmitter();

constructor(private  svc:PaymenthubService){}
  
ngOnInit():void{
  if(this.paymentId!=undefined)
  this.svc.getpaymentbyId(this.paymentId).subscribe(
    (response)=>{
     this.payment=response;
     console.log(response);
     this.sendPayment.emit({payment:this.payment})
    }
  )

}


getpaymentbyId(id:any):void{
  this.svc.getpaymentbyId(id).subscribe(
    (response)=>{
     this.payment=response;
     console.log(response);
     this.sendPayment.emit({payment:this.payment})
    }
  )

}
}
