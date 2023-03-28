import { Component } from '@angular/core';
import { Product } from '../product';

@Component({
  selector: 'search-product',
  templateUrl: './search-product.component.html',
  styleUrls: ['./search-product.component.css']
})
export class SearchProductComponent {
  productId: any;
  product: Product | undefined;

  reciveProduct($event: any) {
    console.log("event catched")
    this.product = $event.product;
    console.log(this.productId);
  }
}
