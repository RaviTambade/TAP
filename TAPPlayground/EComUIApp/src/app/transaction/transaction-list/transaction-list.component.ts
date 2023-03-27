import { Component, OnInit } from '@angular/core';
import { Transaction } from '../transaction';
import { TransactionHubService } from '../transaction-hub.service';

@Component({
  selector: 'transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.css']
})
export class TransactionListComponent implements OnInit {

constructor(private svc:TransactionHubService){}

transactions:Transaction[]|undefined;

ngOnInit():void{
  this.svc.getAllTransactions().subscribe(
    (response) =>{
      this.transactions=response;
      console.log(response);
    });
  }
}
