import { Component } from '@angular/core';
import { Employee } from '../Employee';
import { HRHUBService } from '../hrhub.service';
import { HRModuleModule } from '../hrmodule.module';

@Component({
  selector: 'Empinsert',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertComponent {

  employee: Employee = {
    empId: 0,
    empFirstName: '',
    empLastName: '',
    birthDate: '',
    hireDate: '',
    contactNumber: '',
    email: '',
    password: '',
    photo: '',
    reportsTo: 0,
    accountNumber: ''
  };

  status:boolean |undefined;

  constructor(private svc:HRHUBService){}

  insertEmployee(form:any){
    this.svc.insert(form).subscribe(
      (response)=>{
        this.status=response;
        console.log(response);
      },(error)=>{
        this.status=false;
      }

    )
  }





}
