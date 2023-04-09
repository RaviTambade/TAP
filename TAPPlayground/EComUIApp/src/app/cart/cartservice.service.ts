import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cart } from './cart';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http:HttpClient) { }

  getCart(id:number):Observable<Cart>{
    let url="http://localhost:5235/api/cart/getcartdetails/"+id;
    return this.http.get<Cart>(url);
  }
}
