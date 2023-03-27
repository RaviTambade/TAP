import { Component, EventEmitter, Output } from '@angular/core';
import { Supplier } from '../supplier';
import { SupplierhubService } from '../supplierhub.service';

@Component({
  selector: 'app-getsupplier',
  templateUrl: './getsupplier.component.html',
  styleUrls: ['./getsupplier.component.css']
})
export class GetsupplierComponent {
  supplierId: number | undefined;
  supplier: Supplier | undefined;

  @Output() sendSupplier =new EventEmitter();
  constructor(private svc: SupplierhubService) { }

  getSupplierById(id: any) {
    this.svc.getById(id).subscribe((response) => {
      this.supplier = response;
      this.sendSupplier.emit({supplier:this.supplier});
      console.log(this.supplier);
    })

  }
}
