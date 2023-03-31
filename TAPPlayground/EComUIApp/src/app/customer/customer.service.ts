import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from './Customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http:HttpClient) { }

  getAll():Observable<any>
  {
    let url ="http://localhost:5223/customers/getall";
    return this.http.get(url); 
  }
  getById(customerId:number):Observable<Customer>
  {
    let url ="http://localhost:5223/customers/GetById/"+ customerId;
    return this.http.get<Customer>(url);
  }
  insertCustomer(customer:Customer):Observable<any>
  {
    console.log(customer);
    let url ="http://localhost:5223/customers/InsertCustomer";
    return this.http.post<Customer>(url, customer);
  }
  updateCustomer(customer:Customer):Observable<any>
  {
    let url ="http://localhost:5223/customers/UpdateCustomer";
    return this.http.put<Customer>(url,customer);
  }
  deleteCustomer(customerId:number):Observable<any>
  {
    let url ="http://localhost:5223/customers/DeleteCustomer/"+customerId;
    return this.http.delete(url);
  }
}
