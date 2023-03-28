import { Component } from '@angular/core';
import { MembershipService } from '../membership-service.service';
import { MembershipModule } from '../membership.module';

@Component({
  selector: 'app-update-password',
  templateUrl: './update-password.component.html',
  styleUrls: ['./update-password.component.css']
})
export class UpdatePasswordComponent {
email: any;
oldPassword: any;
newPassword: any;
confirmPassword: any;
constructor(private svc:MembershipService){}

onUpdatePassword(form: any) {
  if(this.email=='' || this.newPassword==''){
    alert("please give valid email or password")
    return;
  }
  if(this.newPassword.length < 8 || this.confirmPassword.length < 8){
    console.log(form)
    alert("password should be minimum 8 characters ")
    return;
  }

  if (this.newPassword === this.confirmPassword) {
    console.log(form)
    let formdata={
      email:this.email,
      newPassword: this.newPassword,
      oldPassword:this.oldPassword
    }
    console.log(formdata);
    this.svc.updatePassword(formdata).subscribe((response) => {
      console.log(response);
      if (response) {
        alert("Password changed")
      }
      else {
        alert("OldPassword is wrong")
      }
    })
  }  else{
    alert("password dosen't match")
  }
}

}

