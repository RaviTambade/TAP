import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartserviceService {

  constructor(private http:HttpClient) { }

  get(id:number):Observable<any>{
    let url="http://localhost:5235/api/cart/get"+id;
    return this.http.get<any>(url);
   
  }
}
