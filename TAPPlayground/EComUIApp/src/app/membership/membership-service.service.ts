import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class MembershipService {

  constructor(private svc:HttpClient) { }

  validateUser(form:any):Observable<any>{
    let url="http://localhost:5235/api/auth/users/login";
    return this.svc.post<any>(url,form);
  }

  registerUser(form:any):Observable<any>{

    let url="http://localhost:5235/api/auth/users/register";
    return this.svc.post<any>(url,form);
  }

  forgotPassword(user:any):Observable<any>{
    let url="http://localhost:5235/api/auth/users/forgot-password";
    console.log(user)
    return this.svc.put<any>(url,user);
  }

  updatePassword(user:any):Observable<any>{
    let url="http://localhost:5235/api/auth/users/update-password";
    console.log(user)
    return this.svc.put<any>(url,user);
  }

  updateEmail(user:any):Observable<any>{
    let url="http://localhost:5235/api/auth/users/update-email";
    console.log(user)
    return this.svc.put<any>(url,user);
  }
}
