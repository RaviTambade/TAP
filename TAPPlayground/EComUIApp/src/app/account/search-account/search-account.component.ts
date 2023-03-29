import { Component } from '@angular/core';

@Component({
  selector: 'app-search-account',
  templateUrl: './search-account.component.html',
  styleUrls: ['./search-account.component.css']
})
export class SearchAccountComponent {
account:any;
  receiveAccount($event: any) {
    this.account = $event.account
  }
}
