import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Transaction } from '../transaction';
import { TransactionHubService } from '../transaction-hub.service';

@Component({
  selector: 'get-transaction',
  templateUrl: './get-transaction.component.html',
  styleUrls: ['./get-transaction.component.css']
})
export class GetTransactionComponent implements OnInit{

  @Input() transactionId : number | undefined;
 transaction: Transaction | undefined;

 @Output() sendTransaction = new EventEmitter();
 
 constructor(private svc: TransactionHubService){}

 ngOnInit(): void {
    if(this.transactionId!=undefined)
    this.svc.getTransactionById(this.transactionId).subscribe(
      (res)=> {
        this.transaction=res;
        console.log(res);
        this.sendTransaction.emit({transaction:this.transaction});
      }
    )
  }

 getTransactionById(id : any){
  this.svc.getTransactionById(id).subscribe(
    (response) => {
      this.transaction = response;
      this.sendTransaction.emit({transaction:this.transaction});
      console.log(this.transaction);
    })
 }
}
