import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from './Employee';

@Injectable({
  providedIn: 'root'
})
export class HRHUBService {

  constructor(private http:HttpClient) { }

  public getAll():Observable<any>{

    let url="http://localhost:5223/employees/showall";
    return this.http.get<any>(url);
  }

  public getById(empId:number):Observable<Employee>{
    let url="http://localhost:5223/employees/GetById/"+empId;
    return this.http.get<Employee>(url);
  }

  public insert(employee:Employee):Observable<any>{
       let url="http://localhost:5223/employees/Insert";
       console.log(employee);
    return this.http.post<Employee>(url,employee);
  }

  public update(employee:Employee):Observable<any>{
      let url="http://localhost:5223/employees/Update/"
    return this.http.put<any>(url,employee);
  }

  delete(empId:number):Observable<any>{
    let url="http://localhost:5223/employees/delete/"+empId;
    return this.http.delete<any>(url);
  }
}
