import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'insertCustomer',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertComponent  {
  
  customer={
    "customerId":1,
    "firstName":'',
    "lastName":'',
    "email":'',
    "contactNumber":0,
    "accountNumber":0,
    "password":''
  };
  status: boolean | undefined;

  constructor(private svc:CustomerService){}

  receiveCustomer($event: any) {
    this.customer = $event.customer;
  }

  insertCustomer(_customerForm:any){
    console.log("sending"+this.customer.firstName);
    this.svc.insertCustomer(this.customer).subscribe((Response)=>{
      this.status=Response;
      console.log(Response);
    })
  }
}
