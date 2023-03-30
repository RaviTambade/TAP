import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Account } from '../account';
import { AccountHubServiceService } from '../account-hub-service.service';

@Component({
  selector: 'app-accountdetails',
  templateUrl: './accountdetails.component.html',
  styleUrls: ['./accountdetails.component.css']
})
export class AccountdetailsComponent implements OnInit {
    
    status: boolean | undefined;
   
    @Input() accountId: number | undefined;
    account: Account | any; 

    @Output() sendAccount =new EventEmitter();
 
    constructor(private svc: AccountHubServiceService,private datepipe:DatePipe) { }
  ngOnInit():void{
    if (this.accountId != undefined)
    this.svc.getById(this.accountId).subscribe((response) => {
      this.account = response;
      this.account.registerDate=this.datepipe.transform(this.account.registerDate,'yyyy-MM-dd hh.mm.ss')
      console.log(this.account.registerDate);
     this.sendAccount.emit({account:this.account});
      console.log(this.account);
    })

  }
   
     getById(accountId:any){
       this.svc.getById(accountId).subscribe((response) => {
         this.account = response;
         this.account.registerDate=this.datepipe.transform(this.account.registerDate,'yyyy-MM-dd hh.mm.ss')
         console.log(this.account.registerDate);
        this.sendAccount.emit({account:this.account});
         console.log(this.account);
       })
   
     }
}
