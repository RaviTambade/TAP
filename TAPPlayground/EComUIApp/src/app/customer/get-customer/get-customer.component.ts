import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Customer } from '../Customer';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-get-customer',
  templateUrl: './get-customer.component.html',
  styleUrls: ['./get-customer.component.css']
})
export class GetCustomerComponent implements OnInit{
  @Input() customerId: number | undefined;
  customer: Customer | undefined;

  @Output() sendCustomer =new EventEmitter();
  constructor(private svc: CustomerService) { }
  
  ngOnInit(): void {
    if(this.customerId!=undefined){
    this.svc.getById(this.customerId).subscribe((response) => {
    this.customer = response;
    this.sendCustomer.emit({customer:this.customer});
    console.log(this.customer);
})
}
}

  getCustomerById(id: any) {
    this.svc.getById(id).subscribe((response) => {
      this.customer = response;
      this.sendCustomer.emit({customer:this.customer});
      console.log(this.customer);
    })
  }
}
