import { Component, Input, OnInit } from '@angular/core';
import { Transaction } from '../transaction';
import { TransactionHubService } from '../transaction-hub.service';
import { ActivatedRoute, Route, Router  } from '@angular/router';

@Component({
  selector: 'details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
 @Input() transaction: Transaction | any;
 status : boolean | undefined;
 tranId: any | undefined;

  constructor(private svc:TransactionHubService,private router:Router,private route:ActivatedRoute ){}
 ngOnInit(): void{
   this.route.paramMap.subscribe((params)=>{
    this.tranId=params.get('id');
   });
 }

 delete(){
  console.log(this.transaction.transactionId);
   this.svc.deleteTransaction(this.transaction.transactionId).subscribe(
    (data)=>{
      this.status=data;
      if(data){
        alert("Transaction Deleted Successfully");
      }
      else{
        {alert("Error")}
      }
      console.log(data);
    }
   )
 }

 recieveTransaction($event:any){
  this.transaction=$event.transaction;
 }

 onUpdateClick(transactionId:number){
  this.router.navigate(['Transaction/transaction-update',transactionId]);
 }
 

}
