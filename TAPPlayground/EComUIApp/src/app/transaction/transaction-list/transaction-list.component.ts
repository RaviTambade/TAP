import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Transaction } from '../transaction';
import { TransactionHubService } from '../transaction-hub.service';

@Component({
  selector: 'transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.css']
})
export class TransactionListComponent implements OnInit {

constructor(private svc:TransactionHubService, private router:Router){}

transactions:Transaction[]|undefined;

ngOnInit():void{
  this.svc.getAllTransactions().subscribe(
    (response) =>{
      this.transactions=response;
      console.log(response);
    });
  }

  onClick(tranId:number){
    this.router.navigate(['Transaction/transacation-details', tranId]);
  }
}
