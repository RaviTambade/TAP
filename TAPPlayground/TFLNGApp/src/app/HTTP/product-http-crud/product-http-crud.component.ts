import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';

@Component({
  selector: 'product-http-crud',
  templateUrl: './product-http-crud.component.html',
  styleUrls: ['./product-http-crud.component.css']
})
export class ProductHttpCRUDComponent implements OnInit {
  data: Object;
  loading: boolean;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.loading = true;
    this.http.get('http://localhost:7000/api/products')
                            .subscribe(data => {
                                                this.data = data;
                                                this.loading = false;
                            });
  }

  Post(): void {
    this.loading = true;
    let dataPost= {
      "productID":3000,
      "title":"Royal Seed Green",
      "category":"Orchid",
      "description":"Seed Orchid is a symbol of royalty. If you want to show your gratitude to someone, do so with this amazing bunch of 6 Blue Orchids, wrapped in Blue special paper along with Arica Palm Leaves. Anyone would be pleased to receive it.",
      "paymentTerm":"40% cash on order",
      "delivery":"4 Day after Order Confirmation",
      "picture":"/images/flowers/Orchid/RoyalBlue.jpg",
      "price":900.0,
      "quantity":634};


     const headers = new HttpHeaders().set("content-type", "application/json"); 
     this.http.post('http://localhost:7000/api/products',dataPost,{ headers })
                              .subscribe(data => {
                                this.data = data;
                                this.loading = false;
                              });
  }

  Update(): void {
    this.loading = true;
    
  
    let dataUpdate={  
      "title":"Royal Seed Green",
      "category":"Orchid",
      "description":"Seed Orchid is a symbol of royalty. If you want to show your gratitude to someone, do so with this amazing bunch of 6 Blue Orchids, wrapped in Blue special paper along with Arica Palm Leaves. Anyone would be pleased to receive it.",
      "paymentTerm":"60% cash on order",
      "delivery":"5 Day after Order Confirmation",
      "picture":"/images/flowers/Orchid/RoyalBlue.jpg",
      "price":300.0,
      "quantity":3000};

    const headers = new HttpHeaders().set("content-type", "application/json");
    this.http.put('http://localhost:7000/api/products/3000',dataUpdate,{headers})
                                .subscribe(data => {
                                                    this.data = data;
                                                    this.loading = false;
                                });
  }

  Delete(): void {
    this.loading = true;
    let headers = new HttpHeaders();
    headers=headers.append("Content-Type", "application/json") ;
    this.http.delete('http://localhost:7000/api/products/191',{headers })
                              .subscribe(data => {
                                this.data = data;
                                this.loading = false;
                              });
  }

  makeHeaders(): void {
    const headers: HttpHeaders = new HttpHeaders({
      //'X-API-TOKEN': 'ng-token'
    });

   const req = new HttpRequest('GET','http://localhost:7000/api/products/3000',{headers: headers});
   this.http.request(req).subscribe(data => {this.data = data['body'];});
  }
}