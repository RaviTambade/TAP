import { Component } from '@angular/core';
import { Product } from '../product';
import { ProductHubService } from '../producthub.service';

@Component({
  selector: 'insert',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertComponent {
  product: Product = {
    productId:0,
    productTitle: '',
    description: '',
    stockAvailable: 0,
    unitPrice: 0,
    imageUrl: '',
    categoryId: 0,
    supplierId: 0
  };
  status: boolean | undefined;
  

  constructor(private svc: ProductHubService) { }

 
  insertProduct() {
    console.log(this.product)
    this.svc.insertProduct(this.product).subscribe((response) => {
      this.status = response;
      console.log(response);
    })
  }
}
