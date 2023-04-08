import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MembershipService } from '../membership-service.service';
import { User } from '../user';

@Component({
  selector: 'new-password',
  templateUrl: './new-password.component.html',
  styleUrls: ['./new-password.component.css']
})
export class NewPasswordComponent {
  @Input() email: any;
  password: any;
  confirmPassword: any;

  constructor(private svc: MembershipService) { }

  onForgotPassword(form: any) {

    if (this.password.length < 8) {
      console.log(form)
      alert("password should be minimum 8 characters ")
      return;
    }

    if (this.password === this.confirmPassword) {
      console.log(form)
      let user: User = {
        email: this.email,
        password: this.password
      }
      console.log(user);
      this.svc.forgotPassword(user).subscribe((response) => {
        console.log(response);
        if (response) {
          alert("Password changed")
        } else {
          alert("Error while changing password")
        }
      });
    } else {
      alert("password dosen't match")
    }
  }
}       