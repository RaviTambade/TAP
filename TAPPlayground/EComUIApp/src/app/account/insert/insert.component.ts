import { Component } from '@angular/core';
import { Account } from '../account';
import { AccountHubServiceService } from '../account-hub-service.service';

@Component({
  selector: 'app-insert',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertComponent {
    account: Account = {
      accountId: 0,
      accountNumber:0,
      ifscCode: '',
      registerDate:'',
      balance: 0
    };
    status: boolean | undefined;
  //   model={
  
  //     "accountNumber":0,
  //     "ifscCode": "",
  //     "registerDate": "yy-mm-dd hh.mm.ss",
  //     "balance": 0
  // };
  
  
    constructor(private svc: AccountHubServiceService) { }
  
    // reciveAccount($event: any) {
    //   this.account = $event.account;
      
    // }
    insertAccount(form :any) {
      console.log("Inserting Account Details");
      console.log(form);
      this.svc.insert(form).subscribe((response) => {
  
        this.status = response;
        console.log(response);
        
      },(error)=>{
        this.status=false
      }
      )
  
      
    }
}
