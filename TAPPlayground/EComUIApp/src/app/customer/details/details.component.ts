import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from '../Customer';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  
  @Input() customer: Customer | undefined;
  customerId:any;
  status: boolean | undefined
  constructor(private svc:CustomerService, private route:ActivatedRoute,private router:Router){}
 
  ngOnInit(): void {
    this.route.paramMap.subscribe((params)=>{
     console.log(params)
     this.customerId=params.get('id');
   })
   }

   reciveCustomer($event: any) {
    console.log("event catched");
     console.log($event.customer)
    this.customer = $event.customer;
  }
 
 
  deleteAccount(customerId: number) {
    if(confirm("Are you sure to delete "+ this.customer?.firstName)) {
  this.svc.deleteCustomer(customerId).subscribe((response) => {

    if(response){
      alert("customer deleted Successfully")
      window.location.reload()
    }
    else{
      alert("Error while deleting customer  ")
    }
    })
  }

}

onSelectUpdateCustomer(customerId:any)
{
  this.router.navigate(['Customer/updateCustomer', customerId])
}

}