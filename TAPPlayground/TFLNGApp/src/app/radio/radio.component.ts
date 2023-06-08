import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { generate } from 'rxjs';

@Component({
  selector: 'app-radio',
  templateUrl: './radio.component.html',
  styleUrls: ['./radio.component.css']
})
export class RadioComponent {

  names:any=[];
  form = new FormGroup({
    gender: new FormControl('', Validators.required)
  });
   
  
  get f(){
    return this.form.controls;
  }
   
  submit(){
    console.log(this.form.value);
  }
 

  changeGender(e:any) {
    console.log(e.target.value);

    if(e.target.value =="male")
    {
      this.names=[];
      this.names.push("Vedant");
      this.names.push("Sameer");
      this.names.push("Chaitanya");
      this.names.push("Virendara");
    }
    else{
      this.names=[];
      this.names.push("Pragati");
      this.names.push("Shubhangi");
      this.names.push("Shamal");
      this.names.push("Ragini");
    }

  }
}
