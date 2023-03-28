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
  transaction: Transaction | undefined;
  datepipe: any;

   constructor(private svc: TransactionHubService){}

   getTransactionById(id : any){
    this.svc.getTransactionById(id).subscribe(
      (response)=>{
        this.transaction = response;
        this.transaction.transactionDate=this.datepipe.transaform(this.transaction.transactionDate,"yyyy-mm-dd hh.mm.ss");
        console.log(this.transaction.transactionDate);
      })
   }
}
