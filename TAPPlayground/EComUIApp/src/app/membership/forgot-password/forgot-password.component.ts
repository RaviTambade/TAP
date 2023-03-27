import { Component } from '@angular/core';

@Component({
  selector: 'forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent {
  email: any;
  otp:number=123456;
  userotp: number| undefined;
  validateStatus: boolean = false;

  sendOTP(form:any) {
   this.otp=123456;
    console.log(this.otp);
  }
  validateOTP(form:any) {
  
    if (this.otp === this.userotp) {
      this.validateStatus = true;
    }
    else
      alert("OTP verification failed")
  }
}
