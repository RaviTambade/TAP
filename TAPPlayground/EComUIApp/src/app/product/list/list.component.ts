import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../product';
import { ProductHubService } from '../producthub.service';

@Component({
  selector: 'list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent {
  products: Product[] | undefined;
  path = "assets/";
  constructor(private svc: ProductHubService,private router:Router) { }
  
  ngOnInit(): void {
    this.svc.getProducts().subscribe((response) => {
      this.products = response;
      console.log(this.products);
    })
  }

//   getAll(): void {
//     this.svc.getProducts().subscribe((response) => {
//       this.products = response;
//       console.log(this.products);
//     })
// }
onSelect(product:any){
  if(product!=undefined)
 this.router.navigate(['Catalog/product',product.productId]);
}
}
