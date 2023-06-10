import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { LoginService } from '../loginservice';

export class Credential  {
  constructor(public  password:string,
              public  email:string){   }
  }

@Component({
  selector: 'sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  isValidUser:boolean=false;
  user: Credential=new Credential("seed","ravi.tambade@transflower.in");
 
  constructor(private svc:LoginService) {    }   
  ngOnInit() {
  this.user=new Credential("seed","ravi.tambade@transflower.in");
  }

  onSubmit(form: any): void {
    this.isValidUser=this.svc.validate(form.email,form.password);
   if(this.isValidUser){
    console.log("Valid User !");
   }
   else{
     console.log("Invalid User !");
   }   
}
}
