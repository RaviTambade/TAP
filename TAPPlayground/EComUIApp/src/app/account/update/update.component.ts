import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { Account } from '../account';
import { AccountHubServiceService } from '../account-hub-service.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent {


  account: Account | any;
  status: boolean | undefined;


  constructor(private svc: AccountHubServiceService) { }

  update() {
    
    this.svc.update(this.account).subscribe((response) => {
      this.status = response;
      console.log(response);
    })
  }
  receiveAccount($event: any) {
    this.account = $event.account
  }
}
