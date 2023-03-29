import { Component } from '@angular/core';
import { Customer } from '../Customer';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'updateCustomer',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent {
  customer: Customer | any;
  status: boolean | undefined;

  constructor(private svc:CustomerService){}
  
  updateCustomer() {
    this.svc.updateCustomer(this.customer).subscribe((response) => {
      this.status = response;
      console.log(response);
    })
  }
  receiveCustomer($event: any) {
    this.customer = $event.customer
    console.log("customer"+ this.customer);
  }
}
