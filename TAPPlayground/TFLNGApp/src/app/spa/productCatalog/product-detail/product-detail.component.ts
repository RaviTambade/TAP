import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  currentProductId:number=12;

  ngOnInit() {  }

  constructor(private router: Router) {  }


  addToCart():void {
    let id=23;
    console.log(" adding to cart");

    this.router.navigate(['./addtocart/', id]);
  }

  goToUpdate(): void {
   let  id=23;
  this.router.navigate(['./update/', id]);
  }

  goToDelete(id:number): void {
   // let id=23;
    this.router.navigate(['./delete/', id]);
  }
}