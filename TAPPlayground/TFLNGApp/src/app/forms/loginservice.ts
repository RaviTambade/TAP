import { Injectable } from '@angular/core';
@Injectable()
export class LoginService {
 validate(user: string, password: string): boolean {
   
    if (user === 'ravi.tambade@transflower.in' && password === 'seed') {
        console.log("checked True");
     // localStorage.setItem('username', user);
      return true;
    }
    
    return false;
 }

 logout(): any {   localStorage.removeItem('username'); }
 getUser(): any {   return localStorage.getItem('username'); }
 isLoggedIn(): boolean {    return this.getUser() !== null;  }
}