import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/product/product';
import { Customer } from '../Customer';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'list-Customers',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  
  customers:Customer[] |undefined;
  constructor(private svc:CustomerService, private router:Router){}
  
  ngOnInit(): void {
    this.svc.getAll().subscribe((response)=>
    {
        this.customers=response;
        console.log(response);
    })
  }

  onSelectCustomer(customer:any){
    if(customer!=undefined)
    this.router.navigate(['Customer/customer',customer.customerId]);
    console.log(customer);
  }
  

}
