import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray} from '@angular/forms';
  
@Component({
  selector: 'check-box',
  templateUrl: './check-box.component.html',
  styleUrls: ['./check-box.component.css']
})
export class CheckBoxComponent implements OnInit{
  form: FormGroup;
  roles: any = [
    { id: 1, name: 'Manager' },
    { id: 2, name: 'User' },
    { id: 3, name: 'Admin' },
    {id:4, name:'Director'}
  ];
  
  constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      role: this.formBuilder.array([], [Validators.required])
    })
  }

  ngOnInit(): void {
      //get rest api call
      //onsubscribe fetch list of roles from database
      //bind to roles array

  }
    
  onCheckboxChange(e:any) {
    console.log("Something is happened");
    const role: FormArray = this.form.get('role') as FormArray;
    if (e.target.checked) {
      role.push(new FormControl(e.target.value));
    } else {
       const index = role.controls.findIndex(x => x.value === e.target.value);
       role.removeAt(index);
      }
    }
      
    submit(){
      console.log(this.form.value);
      //call rest api to store assigned roles to user 
      //in database
    }
}
