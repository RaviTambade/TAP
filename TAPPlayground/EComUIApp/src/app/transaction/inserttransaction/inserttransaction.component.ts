import { Component } from '@angular/core';
import { Transaction } from '../transaction';
import { TransactionHubService } from '../transaction-hub.service';

@Component({
  selector: 'inserttransaction',
  templateUrl: './inserttransaction.component.html',
  styleUrls: ['./inserttransaction.component.css']
})
export class InserttransactionComponent {
  
  transaction:Transaction = {
    transactionId: 0,
    fromAccountNumber: 0,
    toAccountNumber: 0,
    transactionDate: '',
    amount: 0
  };
  status: boolean | undefined;


  constructor(private svc: TransactionHubService){}

  insertTransaction(form:any){
    this.svc.insertTransaction(form).subscribe(
      (response) => {
        this.status=response;
        console.log(response);
  })
  }
}
