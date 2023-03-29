import { Component } from '@angular/core';
import { Productsupplier } from '../productsupplier';
import { SupplierhubService } from '../supplierhub.service';

@Component({
  selector: 'app-productssupplier',
  templateUrl: './productssupplier.component.html',
  styleUrls: ['./productssupplier.component.css']
})
export class ProductssupplierComponent {
supplierId :number |undefined;
productSuppliers: any |undefined;
constructor(private svc:SupplierhubService){}

getProductSupplierById(id:any){
  console.log(this.supplierId);
  this.svc.getProductSupplier(id).subscribe((response)=> {
    this.productSuppliers=response;
    console.log(this.productSuppliers);
  })
}
}
