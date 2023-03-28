import { Component, EventEmitter, Output } from '@angular/core';
import { Transaction } from '../transaction';
import { TransactionHubService } from '../transaction-hub.service';

@Component({
  selector: 'get-transaction',
  templateUrl: './get-transaction.component.html',
  styleUrls: ['./get-transaction.component.css']
})
export class GetTransactionComponent {
 transactionId: number | undefined;
 transaction: Transaction | undefined;

 @Output() sendTransaction = new EventEmitter();
 
 constructor(private svc: TransactionHubService){}

 getTransactionById(id : any){
  this.svc.getTransactionById(id).subscribe(
    (response) => {
      this.transaction = response;
      this.sendTransaction.emit({transaction:this.transaction});
      console.log(this.transaction);
    })
 }
}
