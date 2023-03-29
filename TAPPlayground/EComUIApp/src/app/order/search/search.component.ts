import { Component } from '@angular/core';
import { Order } from '../order';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  orderId: any;
  order: Order | undefined;

  receiveOrder($event: any) {
    console.log("event catched")
    this.order = $event.order;
    console.log(this.orderId);
  }

}
