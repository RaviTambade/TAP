import { Component } from '@angular/core';
import { MembershipService } from '../membership-service.service';
import { User } from '../user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private svc:MembershipService){}

  user:User = {
    email: '',
    password: ''
  }
  onLogin() {
    console.log(this.user);
    this.svc.validateUser(this.user).subscribe((response)=>{
      console.log(response);
      if(response){
        alert("Login sucessfull")
      }
      else
      {
        alert("Login Failed")
      }
    })

  }
}
