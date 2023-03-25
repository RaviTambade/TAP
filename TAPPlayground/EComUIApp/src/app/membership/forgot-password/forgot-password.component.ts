import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent {
  email: any;
  otp: any;
  userotp: any;
  validateStatus: boolean = false;

  sendOTP() {
    this.otp = 123456;
    console.log(this.otp);
  }
  validateOTP() {
    if (this.otp === this.userotp) {
      this.validateStatus = true;
    }
    else
      alert("OTP verification failed")
  }
}
