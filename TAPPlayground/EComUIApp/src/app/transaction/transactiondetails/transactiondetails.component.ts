import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { Transaction } from '../transaction';
import { TransactionHubService } from '../transaction-hub.service';

@Component({
  selector: 'transactiondetails',
  templateUrl: './transactiondetails.component.html',
  styleUrls: ['./transactiondetails.component.css']
})
export class TransactiondetailsComponent {

  transactionId: number|undefined;
  transaction: Transaction | any;


   constructor(private svc: TransactionHubService, private datepipe:DatePipe){}

   getTransactionById(id : any){
    this.svc.getTransactionById(id).subscribe(
      (response)=>{
        this.transaction = response;
        this.transaction.transactionDate=this.datepipe.transform(this.transaction.transactionDate,'yyyy-MM-dd hh.mm.ss')
        console.log(this.transaction.transactionDate);
      })
   }
}
