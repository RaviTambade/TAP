import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { Account } from './account';


@Injectable({
  providedIn: 'root'
})
export class AccountHubServiceService {

  constructor(private http:HttpClient) { }

  getAccounts():Observable<any>{
    let url =  "http://localhost:5223/accounts/getall";
    return this.http.get<any>(url);  
  }
  
  getById(accountId:number):Observable<any>{
    let url= "http://localhost:5223/accounts/getbyid/"+accountId;
    return this.http.get<any>(url);
    
  } 
  insert(account:Account):Observable<any>{
    let url= "http://localhost:5223/accounts/insert";
    return this.http.post<Account>(url,account);
  }
  update(account:Account):Observable<any>{
    let url="http://localhost:5223/accounts/update";
    return this.http.put<any>(url,account);
   } 
  
  delete(accountId:number):Observable<any>{
    let url="http://localhost:5223/accounts/delete/"+accountId;
    return this.http.delete<any>(url);
  }

}
