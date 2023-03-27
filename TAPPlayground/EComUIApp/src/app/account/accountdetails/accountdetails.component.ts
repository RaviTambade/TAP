import { Component, EventEmitter, Output } from '@angular/core';
import { Account } from '../account';
import { AccountHubServiceService } from '../account-hub-service.service';

@Component({
  selector: 'app-accountdetails',
  templateUrl: './accountdetails.component.html',
  styleUrls: ['./accountdetails.component.css']
})
export class AccountdetailsComponent {
    accountId:number|undefined
    account:Account|undefined
   
    
    @Output() sendAccount =new EventEmitter();
    constructor(private svc: AccountHubServiceService) { }
   
     getById(id:any){
       this.svc.getById(id).subscribe((response) => {
         this.account = response;
         this.sendAccount.emit({account:this.account});
         console.log(this.account);
       })
   
     }

}
