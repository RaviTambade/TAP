import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from './order';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderhubService {

  constructor(private http:HttpClient) { }

  public getAllOrders():Observable<any>{

    let url ="http://localhost:5223/orders/getall";
    return this.http.get<any>(url);
  }

  public getById(orderId:number):Observable<any>{

    let url = "http://localhost:5223/orders/getbyid/" +orderId ;
    return this.http.get<any>(url);
  }

  public insertOrder(order:Order):Observable<any>{
    let url = "http://localhost:5223/orders/insert";
    return this.http.post<Order>(url,order);
  }

  public update(order:Order):Observable<any>{
    let url = "http://localhost:5223/orders/update";
    return this.http.put<any>(url,order);
  }

  public delete(orderId:number):Observable<any>{
    let url = "http://localhost:5223/orders/delete/" +orderId ; 
    return this.http.delete<any>(url);
  }
  
}
