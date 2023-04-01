import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SupplierhubService } from '../supplierhub.service';

@Component({
  selector: 'app-insert',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertComponent {

  supplier= {
    "supplierId": 0,
    "supplierName": '',
    "companyName": '',
    "contactNumber": '',
    "email": '',
    "address": '',
    "city": '',
    "state":'',
    "accountNumber":''
  };
  status: boolean | undefined;
  

  constructor(private svc: SupplierhubService,private router:Router) { }

  insertSupplier(_supplierForm:any) {
    this.svc.insert(this.supplier).subscribe((response) => {
      this.status = response;
      console.log(response);
      if(response){
        alert("Supplier inserted Successfully")
        this.router.navigate(['supplier/suppliers']);
       }
       else{
        alert("Error while inserting supplier")
       }
    })
  }
 
}
