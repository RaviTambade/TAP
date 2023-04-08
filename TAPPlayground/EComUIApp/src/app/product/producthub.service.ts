import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './product';

@Injectable({
  providedIn: 'root'
})
export class ProductHubService {

  constructor(private http:HttpClient) { }
  getProducts():Observable<Product[]>{
    let url =  "http://localhost:5235/api/products/getallproducts";
    return this.http.get<Product[]>(url);
  }

  getProductById(productId:number):Observable<Product>{
    let url= "http://localhost:5235/api/products/getproductdetails/"+productId;
    return this.http.get<Product>(url);
  }
  insertProduct(product:Product):Observable<any>{
    let url= "http://localhost:5235/api/products/addproduct";
    return this.http.post<Product>(url,product);
  }

  deleteProduct(productId:number):Observable<any>{
    let url= "http://localhost:5235/api/products/delete/"+productId;
    return this.http.delete<any>(url);
  }

  updateProduct(product:Product,productId:number):Observable<any>{
    let url= "http://localhost:5235/api/products/update/"+productId
    return this.http.put<any>(url,product);
  }

  getCategories(): Observable<any>{
    let url =  "http://localhost:5235/api/categories/getAll";
    return this.http.get<any>(url);
  }

  getSuppliers(): Observable<any>{
    let url =  "http://localhost:5235/api/suppliers/GetAllSuppliers";
    return this.http.get<any>(url);
  }

  hikePrice(id:number):Observable<any>{
    let url= "http://localhost:5235/api/products/hikeprice/"+ id;
    return this.http.put<any>(url,null);
  }
}
