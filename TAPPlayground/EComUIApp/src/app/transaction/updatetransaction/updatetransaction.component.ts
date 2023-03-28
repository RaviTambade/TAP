import { Component } from '@angular/core';
import { Transaction } from '../transaction';
import { TransactionHubService } from '../transaction-hub.service';

@Component({
  selector: 'updatetransaction',
  templateUrl: './updatetransaction.component.html',
  styleUrls: ['./updatetransaction.component.css']
})
export class UpdatetransactionComponent {
  
    transaction: Transaction|any;
    status: boolean| undefined;

    constructor(private svc: TransactionHubService){ }

    updateTransaction(form:any){
     this.svc.updateTransaction(form).subscribe(
      (response) => {
        this.status = response;
        console.log(response);
      })
    }
    receiveTransaction($event:any){
      this.transaction = $event.transaction;
    }
}
