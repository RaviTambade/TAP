import { Component } from '@angular/core';
import { Supplier } from '../supplier';
import { SupplierhubService } from '../supplierhub.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent {
  supplierId: any;
  supplier:Supplier|undefined;
  status: boolean | undefined;

  constructor(private svc: SupplierhubService) { }

  receiveSupplierId($event: any) {
    this.supplier=$event.supplier;
    this.supplierId = $event.supplier.supplierId;
    console.log(this.supplierId);

  }
  deleteSupplier() {
    console.log(this.supplierId);
    this.svc.delete(this.supplierId).subscribe((response) => {
      this.status = response;
      console.log(response);
    })
  }
}
