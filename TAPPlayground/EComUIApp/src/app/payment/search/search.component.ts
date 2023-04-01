import { Component } from '@angular/core';
import { Payment } from '../payment';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {

paymentId:any;

payment:Payment|undefined;



 recivePayment($event:any){

  this.payment=$event.payment;
  console.log(this.payment);
 }

}
