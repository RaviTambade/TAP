import { Component } from '@angular/core';
import { Supplier } from '../supplier';
import { SupplierhubService } from '../supplierhub.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent {
  supplier: Supplier | any;
  status: boolean | undefined;


  constructor(private svc: SupplierhubService) { }

  updateSupplier() {
    this.svc.update(this.supplier).subscribe((response) => {
      this.status = response;
      console.log(response);
    })
  }
  receiveSupplier($event: any) {
    this.supplier = $event.supplier
  }

}
