import { Component, OnInit } from '@angular/core';
import { LoginserviceService } from '../loginservice.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

  model={userName:"sachin", password:"seed"};
  status:boolean=false;

  constructor(private svc:LoginserviceService) { }

  ngOnInit() {
  }

  onSubmit(form:any){
    console.log(form.userName.value);
    console.log(form.pass.value);

    this.status=this.svc.validate(this.model.userName,
                                  this.model.password);

  }
}
