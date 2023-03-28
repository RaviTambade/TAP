import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Productsupplier } from './productsupplier';
import { Supplier } from './supplier';

@Injectable({
  providedIn: 'root'
})
export class SupplierhubService {

  constructor(private http:HttpClient) { }

  getAll():Observable<any>{
    let url =  "http://localhost:5223/suppliers/getallsuppliers";
    return this.http.get<any>(url);
  }

  getById(supplierId:number):Observable<Supplier>{
    let url= "http://localhost:5223/suppliers/getsupplierbyid/"+supplierId;
    return this.http.get<Supplier>(url);
  }
  insert(supplier:Supplier):Observable<any>{
    let url= "http://localhost:5223/suppliers/insertsupplier";
    return this.http.post<Supplier>(url,supplier);
  }

  delete(supplierId:number):Observable<any>{
    let url= "http://localhost:5223/suppliers/deletesupplier/"+supplierId;
    return this.http.delete<any>(url);
  }

  update(supplier:Supplier):Observable<any>{
    let url= "http://localhost:5223/suppliers/updatesupplier";
    return this.http.put<any>(url,supplier);
  }
  getProductSupplier(supplierId:number):Observable<Productsupplier>{
    let url="http://localhost:5223/suppliers/getproductsupplier/"+supplierId;
    return this.http.get<Productsupplier>(url);
  }
}
