import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {
   role=sessionStorage.getItem("role");

   constructor(private router:Router){}
  canActivate(  
     route: ActivatedRouteSnapshot,
     state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
  {
    console.log(this.role)
      if( this.role === "admin"){
     return true;

   }
   alert("Your Role must be Admin Plese Login")
   this.router.navigateByUrl('/login')
      return false;
  }
  
}
}