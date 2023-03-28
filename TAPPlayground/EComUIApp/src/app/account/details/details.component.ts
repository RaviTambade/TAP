import { Component, Input } from '@angular/core';
import { Account } from '../account';
import { AccountHubServiceService } from '../account-hub-service.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  constructor(private svc: AccountHubServiceService) { }
  @Input() account: Account | any;
  status: boolean | undefined

  deleteAccount() {
    console.log(this.account.accountId);
    this.svc.delete(this.account.accountId).subscribe((data) => {
      this.status = data;
      if (data) { alert("Account Deleted Successfully") 
    }else{
{alert("Error")}
    }
      console.log(data);
    })
  }
}
