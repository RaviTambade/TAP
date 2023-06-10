import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray} from '@angular/forms';
 
@Component({
  selector: 'mutiple-select-list-box',
  templateUrl: './mutiple-select-list-box.component.html',
  styleUrls: ['./mutiple-select-list-box.component.css']
})
export class MutipleSelectListBoxComponent implements OnInit{
   members:any[];
   selectedmembers:any[];
   resultTo:any;
   resultFrom:any;
   form: FormGroup;

  constructor(private formBuilder: FormBuilder){
    this.members=[];
    this.selectedmembers=[];
    this.resultTo="";
    this.resultFrom="";
    this.form = this.formBuilder.group({
      members: this.formBuilder.array([])
    })
  }

  ngOnInit(): void {
    //get data from rest api and assign to members
    this.members=["Shiv","Ganesh", "Charu", "Rajiv"];
    this.selectedmembers=[];
  }

  changeMembersFrom(e: any){
   this.resultFrom=e.target.value; 
  }

  changeMembersTo(e: any){
    this.resultTo=e.target.value;
  }

  submit1(){
    this.members=this.members.filter((item)=>{return (item !=this.resultFrom)});
    this.selectedmembers.push(this.resultFrom);
  }

  submit2(){
    this.selectedmembers=this.selectedmembers.filter((item)=>{return (item !=this.resultTo)});
    this.members.push(this.resultTo);
  }
}