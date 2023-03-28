import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { Account } from '../account';
import { AccountHubServiceService } from '../account-hub-service.service';

@Component({
  selector: 'app-accountdetails',
  templateUrl: './accountdetails.component.html',
  styleUrls: ['./accountdetails.component.css']
})
export class AccountdetailsComponent {
    accountId:any|undefined
    account:Account|any
    status: boolean | undefined;
   
    
    @Output() sendAccount =new EventEmitter();
 
    constructor(private svc: AccountHubServiceService,private datepipe:DatePipe) { }
   
     getById(id:any){
       this.svc.getById(id).subscribe((response) => {
         this.account = response;
         this.account.registerDate=this.datepipe.transform(this.account.registerDate,'yyyy-MM-dd hh.mm.ss')
         console.log(this.account.registerDate);
        this.sendAccount.emit({account:this.account});
         console.log(this.account);
       })
   
     }

    

}
