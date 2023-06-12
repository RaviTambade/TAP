import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute, ParamMap } from '@angular/router'
import { ProductService } from '../../product.service';
@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  currentProductId:any;
  product:any|undefined;
  constructor(private svc:ProductService,private router:Router,private route: ActivatedRoute) {  }
  ngOnInit() { 
    this.currentProductId=this.route.snapshot.paramMap.get("id");
    console.log(this.currentProductId);
    this.product=this.svc.getProduct(this.currentProductId);
    console.log(this.product);
   }

  addToCart():void {
    let id=this.currentProductId;
    this.router.navigate(['./addtocart/', id]);
  }

  goToUpdate(): void {
   let  id=this.currentProductId;
   this.router.navigate(['./update/', id]);
  }

  goToDelete(id:number): void {
    this.router.navigate(['./delete/', id]);
  }
}