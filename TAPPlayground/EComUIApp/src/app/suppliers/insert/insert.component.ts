import { Component } from '@angular/core';
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
  

  constructor(private svc: SupplierhubService) { }

  insertSupplier(_supplierForm:any) {
    this.svc.insert(this.supplier).subscribe((response) => {
      this.status = response;
      console.log(response);
    })
  }
}
