import { Injectable } from '@angular/core';
@Injectable()
export class AuthService {

  login(user: string, password: string): boolean {
      //Call rest api implemented by asp.net web api controller
    if (user === 'ravi' && password === 'seed') {
      localStorage.setItem('username', user);
      let status = localStorage.getItem("loggedInStatus");
      if(status=="false"){
        console.log("changing localstorage value");
        localStorage.setItem("loggedInStatus","true");
      }
      return true;
    }
    return false;
  }

  logout(): any { localStorage.removeItem('username'); }
  getUser(): any { 
    //GET REST API TO KNOW USERS ROLS FROM DATATABASE
    //return role as part of user object 
    return localStorage.getItem('username'); 
  }
  isLoggedIn(): boolean { return this.getUser() !== null;}
}