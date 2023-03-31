import { Component, OnInit } from '@angular/core';
import { Customer } from '../Customer';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'list-Customers',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  
  customers:Customer[] |undefined;
  constructor(private svc:CustomerService){}
  
  ngOnInit(): void {
    this.svc.getAll().subscribe((response)=>
    {
        this.customers=response;
        console.log(response);
    })
  }

  
}
