import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'customerlist-details',
  templateUrl: './customerlist-details.component.html',
  styleUrls: ['./customerlist-details.component.css']
})
export class CustomerlistDetailsComponent implements OnInit {
  customers:any[]=[];
  selectedCustomer: any;
  constructor(private svc:CustomerService){ 
  }

  ngOnInit(): void {
    this.customers=this.svc.getAll();
    this.selectedCustomer=this.customers[0];
  }

  onSelectCustomer(customer:any){
   this.selectedCustomer = customer;
  }
}
