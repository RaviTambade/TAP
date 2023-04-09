import { Component, EventEmitter, Output } from '@angular/core';
import { MembershipService } from '../membership-service.service';
import { User } from '../user';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private svc:MembershipService){}
// role :string |undefined
  user:User = {
    email: '',
    password: ''
  }

  onLogin(form:any){
    console.log(form);
    this.svc.validateUser(form).subscribe((response)=>{
          console.log(response);
          
          if(response){
            alert("Login sucessfull")
            window.location.reload();
          }
          else
          {
            alert("Login Failed")
          }
        })
  }
}
