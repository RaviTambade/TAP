import { Component } from '@angular/core';
import { MembershipService } from '../membership-service.service';

@Component({
  selector: 'app-update-email',
  templateUrl: './update-email.component.html',
  styleUrls: ['./update-email.component.css']
})
export class UpdateEmailComponent {
oldEmail: any;
password: any;
newEmail: any;
constructor(private svc:MembershipService){}


onUpdateEmail(form: any) {

  if(this.oldEmail=='' || this.password=='' || this.newEmail==''){
    alert("please give valid email or password")
    return;
  }

this.svc.updateEmail(form).subscribe((response) => {
  console.log(response);
  if (response) {
    alert("Email changed")
  }
  else {
    alert("Error while updating email")
  }
})

}

}
