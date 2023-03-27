import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Observable } from 'rxjs';
import { Product } from './product';

@Injectable({
  providedIn: 'root'
})
export class ProducthubService {


  constructor(private http:HttpClient) {
  
   }

   getAllProducts():Observable<Product[]>{
    let url="http://localhost:5223/product/getall";
    return this.http.get<Product[]>(url);
   }

   getById(id:number):Observable<Product>{
    let url="http://localhost:5223/product/getbyid/"+id;
    return this.http.get<Product>(url);
   }
  
}
