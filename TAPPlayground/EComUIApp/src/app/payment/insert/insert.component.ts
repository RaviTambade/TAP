import { Component, OnInit } from '@angular/core';
import { Payment } from '../payment';
import { PaymenthubService } from '../paymenthub.service';

@Component({
  selector: 'ap-insert',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertComponent implements OnInit {

  payment: Payment ={
    paymentId:0,
    paymentDate:'',
    paymentMode:'',
    transactionId:0,
    orderId:0

  }
status :boolean |undefined
// model={

//  " paymentId":0,
//     "paymentDate":'',
//     "paymentMode":"",
//     "transactionId":'',
//     "orderId":''
// };
constructor(private svc:PaymenthubService){}


ngOnInit(): void {

}

insert(form:any){

  this.svc.insert(form).subscribe(
    (response)=>{
      this.status=response;
      console.log(response)
    }
  )

}


}
