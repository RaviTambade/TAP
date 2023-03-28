import { Component } from '@angular/core';

@Component({
  selector: 'assignrole',
  templateUrl: './assignrole.component.html',
  styleUrls: ['./assignrole.component.css']
})
export class AssignroleComponent {


role: any;
email: any;

onSubmit() {
  console.log( "Role " +this.role +" assigned to " +this.email)
  }
}
