import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProducthubService {

  constructor(private http : HttpClient) { }
  private subject = new Subject<any>();
  public getAllProducts():Observable<any>{
    let url = "http://localhost:5137/product";
    return this.http.get<any>(url);
  }
  sendProduct(data:any){
    let product = data.selectedProduct;
    console.log("Service is called");
    console.log(product);

  switch(product){
    case "oats":{
      let url = " http://localhost:5137/api/product/"+ product;
      this.http.get(url).subscribe((data) =>{
        console.log(data);
        this.subject.next({data,product});
      });
      break;
    }
    case "wheat":{
      let url = "http://localhost:5137/api/product/"+ product;
      this.http.get(url).subscribe((data) =>{
        console.log(data);
        this.subject.next({data,product});
      });
      break;
    }
    case "manure":{
      let url = "http://localhost:5137/api/product/"+ product;
      this.http.get(url).subscribe((data) =>{
        console.log(data);
        this.subject.next({data,product});
      });
      break;
    }
  }
}
getData(): Observable<any>{
  return this.subject.asObservable();
}



public getCategories():Observable<any>{
  let url = "http://localhost:5137/api/categories/categories";
  return this.http.get<any>(url);
}

public getProducts(category:string):Observable<any>{
  let url="http://localhost:5137/api/products/category/"+ category;
  return this.http.get<any>(url);
}
}
