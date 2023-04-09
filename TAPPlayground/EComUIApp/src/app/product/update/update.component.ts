import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../product';
import { ProductHubService } from '../producthub.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  product: Product|any;
  status: boolean | undefined;
  productId: any;

 
  constructor(private svc: ProductHubService,private route:ActivatedRoute,private router:Router) { }
  ngOnInit(): void {
   
    this.route.paramMap.subscribe((params)=>{
      console.log(params)
      this.productId=params.get('id');
  })
  }

  updateProduct() {
    this.svc.updateProduct(this.product,this.productId).subscribe((response)=>{
      this.status = response;
      console.log(response);
      if(response)
      {
        this.router.navigate(['Catalog/product',this.product.productId]);
        alert("record updated successfully")
      }
      else{
        alert("Error while updating")
      }
    })

  }

  // from getbyid
  reciveProduct($event: any) {
    this.product = $event.product
  }

}
