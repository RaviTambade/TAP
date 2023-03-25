import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class MembershipService {

  constructor(private svc:HttpClient) { }

  validateUser(user:User):Observable<any>{
    let url="http://localhost:5223/secure/validate";
    return this.svc.post<any>(url,user);
  }

  registerUser(user:User):Observable<any>{

    let url="http://localhost:5223/secure/register";
    return this.svc.post<any>(url,user);
  }

  changePassword(user:User):Observable<any>{
    let url="http://localhost:5223/secure/changepassword";
    return this.svc.put<any>(url,user);
  }
}
