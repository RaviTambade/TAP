import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from '../Customer';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'updateCustomer',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit{
  customer: Customer | any;
  sub:any;
  customerId:any
  status: boolean | undefined;

  constructor(private svc:CustomerService, private route:ActivatedRoute,private router:Router){}
  ngOnInit(): void {
    this.sub=this.route.paramMap.subscribe((params)=>
    {
      this.customerId=params.get('id');
    })
  }
  
  updateCustomer() {
    this.svc.updateCustomer(this.customer).subscribe((response)=>{
      this.status = response;
      console.log(response);
      if(response)
      {
        this.router.navigate(['/customer',this.customer.customerId]);
        alert("record updated successfully")
      }
      else{
        alert("Error while updating")
      }
    })

  }
  receiveCustomer($event: any) {
    this.customer = $event.customer;
  }
}
