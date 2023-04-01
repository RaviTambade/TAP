import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../product';
import { ProductHubService } from '../producthub.service';

@Component({
  selector: 'product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  @Input() product: Product | undefined;
  
  productId:any
  path = "assets/";
  status: boolean | undefined;

  constructor(private svc: ProductHubService, private route:ActivatedRoute,private router:Router) { }
  ngOnInit(): void {
   this.route.paramMap.subscribe((params)=>{
    console.log(params)
    this.productId=params.get('id');
  })
  }
  reciveProduct($event: any) {
    console.log("event catched")
    this.product = $event.product;
    console.log(this.productId);
  }

  deleteProduct(productId: number) {
      if(confirm("Are you sure to delete "+ this.product?.productTitle)) {
    this.svc.deleteProduct(productId).subscribe((response) => {

      if(response){
        alert("Product deleted Successfully")
        this.router.navigate(['Catalog/products']);
      }
      else{
        alert("Error while deleting Product  ")
      }
      })
    }

  }


  onSelectUpdate(productId:any){
   this.router.navigate(['Catalog/product-update',productId]);
  }

 
}