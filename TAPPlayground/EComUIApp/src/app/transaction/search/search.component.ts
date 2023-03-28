import { Component } from '@angular/core';
import { Transaction } from '../transaction';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {

  transactionId : any;
  transaction : Transaction | undefined;

  receiveTransaction($event:any){
    console.log("Event Catched");
    this.transaction = $event.transaction;
    console.log(this.transactionId);
  }
}
