import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Transaction } from '../transaction';
import { TransactionHubService } from '../transaction-hub.service';

@Component({
  selector: 'updatetransaction',
  templateUrl: './updatetransaction.component.html',
  styleUrls: ['./updatetransaction.component.css']
})
export class UpdatetransactionComponent implements OnInit {
  
    transaction: Transaction|any;
    status: boolean| undefined;
    transactionId:any;


    constructor(private svc: TransactionHubService, private route : ActivatedRoute, private router:Router){ }
    
    ngOnInit():void{
      this.route.paramMap.subscribe((params)=>{
        this.transactionId=params.get('id');
      })
    }
    updateTransaction(form:any){
     this.svc.updateTransaction(form).subscribe(
      (response) => {
        this.status = response;
        console.log(response);
        if(response){
          alert("Transaction Updated Successfully");
          this.router.navigate(['/transaction-list']);
        }
        else{
          alert("Error");
        }

      })
    }
    receiveTransaction($event:any){
      this.transaction = $event.transaction;
    }
}
