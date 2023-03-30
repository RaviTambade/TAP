import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PaymenthubService } from '../paymenthub.service';
import{Payment} from '../payment'
@Component({
  selector: 'ap-payment-details',
  templateUrl: './payment-details.component.html',
  styleUrls: ['./payment-details.component.css']
})
export class PaymentDetailsComponent implements OnInit{

payment:Payment |undefined
paymentId:number |undefined

@Output() sendPayment=new EventEmitter();

constructor(private  svc:PaymenthubService){}
  
ngOnInit():void{

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
