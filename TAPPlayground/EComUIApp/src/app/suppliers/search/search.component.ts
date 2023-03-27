import { Component } from '@angular/core';
import { Supplier } from '../supplier';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  supplierId: any;
  supplier: Supplier | undefined;

  receiveSupplier($event: any) {
    console.log("event catched")
    this.supplier = $event.supplier;
    console.log(this.supplierId);
  }
}
