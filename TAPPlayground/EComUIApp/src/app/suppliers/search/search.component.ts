import { Component } from '@angular/core';
import { Supplier } from '../supplier';
import { SupplierhubService } from '../supplierhub.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  supplierId: any;
  supplier: Supplier | undefined;
  status:boolean |undefined;

  constructor(private svc:SupplierhubService,private router:Router){}

  receiveSupplier($event: any) {
    console.log("event catched")
    this.supplier = $event.supplier;
    this.supplierId = $event.supplier.supplierId;
    console.log(this.supplierId);
  }
   
  deleteSupplier() {
    console.log(this.supplierId);
    this.svc.delete(this.supplierId).subscribe((response) => {
      this.status = response;
      this.router.navigate(['/suppliers']);
      console.log(response);
    })
  }
}
