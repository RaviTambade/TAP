import { Component } from '@angular/core';
import { MembershipService } from '../membership-service.service';
import { User } from '../user';

@Component({
  selector: 'app-register',
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

  onRegister() {
    if (this.user.password === this.confirmPassword) {
      this.svc.registerUser(this.user).subscribe((response) => {
        this.registered = response;
        console.log(response);
        alert("User Registered successfully")
      })
    }
    else{
      alert("password dosen't match")
      return;
    }
  }
}
