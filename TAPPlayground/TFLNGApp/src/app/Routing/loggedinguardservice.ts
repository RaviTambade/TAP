import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AuthService } from './authservice';

@Injectable()
export class LoggedInGuard implements CanActivate {



  //dependecy Injection
  constructor(private authService: AuthService) {
    console.log("constructor is invoked !");
  }

  canActivate(): boolean {
    return this.authService.isLoggedIn();
  }
}