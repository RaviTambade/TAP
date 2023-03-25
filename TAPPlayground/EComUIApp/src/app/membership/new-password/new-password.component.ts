import { Component, Input } from '@angular/core';
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
  ConfirmPassword: any;

  constructor(private svc: MembershipService) { }

  onSubmit() {
    if (this.password === this.ConfirmPassword) {
      let user: User = {
        email: this.email,
        password: this.password
      }
      this.svc.changePassword(user).subscribe((response) => {
        if (response) {
          alert("Password changed")
        }
      })
    } else {
      alert("Error while changing password")
    }
  }
}