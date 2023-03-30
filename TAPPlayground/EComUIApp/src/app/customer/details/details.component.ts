import { Component, Input } from '@angular/core';
import { Customer } from '../Customer';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  
  @Input() customer: Customer | any;
  status: boolean | undefined
  constructor(private svc:CustomerService){}
  deleteAccount() {
    console.log(this.customer.customerId);
    this.svc.deleteCustomer(this.customer.customerId).subscribe((data) => {
      this.status = data;
      if (data) { alert("Customer Deleted Successfully") 
    }else{
{alert("Error")}
    }
      console.log(data);
    })
}
}