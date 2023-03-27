import { Component } from '@angular/core';
import { MembershipService } from '../membership-service.service';
import { User } from '../user';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  user: User = {
    email: '',
    password: ''
  }
  confirmPassword: any;

  registered: boolean =false;

  constructor(private svc: MembershipService) { }

  onRegister( form:any) {
    if(this.user.email=='' || this.user.password==''){
      alert("please give valid email or password")
      return;
    }
    if(this.user.password.length < 8 || this.confirmPassword.length < 8){
      alert("password should be minimum 8 characters ")
      return;
    }

    if (this.user.password === this.confirmPassword) {
      this.svc.registerUser(form).subscribe((response) => {
        this.registered = response;
        console.log(response);
        alert("User Registered successfully")
      })
    }
    else{
      alert("password dosen't match")
    }
  }
}
