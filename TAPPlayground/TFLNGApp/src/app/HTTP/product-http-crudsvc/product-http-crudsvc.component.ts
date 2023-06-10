import { Component, OnInit } from '@angular/core';
import { Product } from '../product';
import { ProductService } from '../producthubservice';

@Component({
  selector: 'product-http-productCRUD',
  templateUrl: './product-http-crudsvc.component.html',
  styleUrls: ['./product-http-crudsvc.component.css']
})
export class ProductHttpCRUDSVCComponent implements OnInit {

 products: Product[];

 constructor(private svc: ProductService) { }

 ngOnInit() {
   this.getProducts();
 }

 getProducts(): void {
   this.svc.getProducts().subscribe(products => this.products = products);
 }

 post(): void {
   console.log("Posting data to insert new recod");
   let prd= {
       "productID": 995,
       "title": "vodafone beatuty",
       "picture": "http://localhost:4200/resources/images/flowers/Gerbera/pinkwrap.jpg",
       "category": "Rose",
       "description": "Roses are famous for their cheerful demeanor but this bunch of 5 Pink Gerberas is more than that. These flowers will spread love along with their smiles in the life of anyone who will receive them. A special surprise for a special person!",
       "price": 1000,
       "quantity": 45000,
       "paymentTerm": "50% advance with order confirmation and 50% before delivery",
       "delivery": "1 Day after order confirmation, Ex-Pune"
     };

   this.svc.addProduct(prd as Product)
     .subscribe(product => {
       this.products.push(product);
     });
 }

 delete(): void {
   console.log("Posting data to remove Existting");
   let theproduct= {
    "productID": 995,
    "title": "vodafone beatuty",
    "picture": "http://localhost:4200/resources/images/flowers/Gerbera/pinkwrap.jpg",
    "category": "Rose",
    "description": "Roses are famous for their cheerful demeanor but this bunch of 5 Pink Gerberas is more than that. These flowers will spread love along with their smiles in the life of anyone who will receive them. A special surprise for a special person!",
    "price": 1000,
    "quantity": 45000,
    "paymentTerm": "50% advance with order confirmation and 50% before delivery",
    "delivery": "1 Day after order confirmation, Ex-Pune"
  };
   this.products = this.products.filter(prd => prd !== theproduct);
   this.svc.deleteProduct(theproduct).subscribe();
 }
}